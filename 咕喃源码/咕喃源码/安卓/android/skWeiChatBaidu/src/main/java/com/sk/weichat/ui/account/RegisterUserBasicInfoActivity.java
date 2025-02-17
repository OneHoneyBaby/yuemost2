package com.sk.weichat.ui.account;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.alibaba.fastjson.JSON;
import com.gunan.im.wxapi.WXHelper;
import com.loopj.android.http.AsyncHttpClient;
import com.loopj.android.http.AsyncHttpResponseHandler;
import com.loopj.android.http.RequestParams;
import com.sk.weichat.AppConstant;
import com.sk.weichat.MyApplication;
import com.sk.weichat.R;
import com.sk.weichat.Reporter;
import com.sk.weichat.bean.Area;
import com.sk.weichat.bean.User;
import com.sk.weichat.bean.WXUserInfo;
import com.sk.weichat.bean.event.MessageLogin;
import com.sk.weichat.db.dao.AreasDao;
import com.sk.weichat.helper.AvatarHelper;
import com.sk.weichat.helper.DialogHelper;
import com.sk.weichat.helper.ImageLoadHelper;
import com.sk.weichat.helper.LoginHelper;
import com.sk.weichat.helper.LoginSecureHelper;
import com.sk.weichat.helper.PrivacySettingHelper;
import com.sk.weichat.helper.QQHelper;
import com.sk.weichat.helper.YeepayHelper;
import com.sk.weichat.map.MapHelper;
import com.sk.weichat.ui.base.BaseActivity;
import com.sk.weichat.ui.tool.ButtonColorChange;
import com.sk.weichat.ui.tool.SelectAreaActivity;
import com.sk.weichat.util.AsyncUtils;
import com.sk.weichat.util.CameraUtil;
import com.sk.weichat.util.DateSelectHelper;
import com.sk.weichat.util.DeviceInfoUtil;
import com.sk.weichat.util.EventBusHelper;
import com.sk.weichat.util.FileUtil;
import com.sk.weichat.util.LogUtils;
import com.sk.weichat.util.StringUtils;
import com.sk.weichat.util.TimeUtils;
import com.sk.weichat.util.ToastUtil;
import com.sk.weichat.util.UiUtils;
import com.sk.weichat.util.secure.DH;
import com.sk.weichat.util.secure.RSA;
import com.sk.weichat.util.secure.chat.SecureChatUtil;
import com.sk.weichat.view.CircleImageView;
import com.sk.weichat.view.TipDialog;
import com.xuan.xuanhttplibrary.okhttp.result.Result;

import org.apache.http.Header;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashMap;
import java.util.Map;

import de.greenrobot.event.Subscribe;
import de.greenrobot.event.ThreadMode;

/**
 * 注册-3.基本资料
 */
public class RegisterUserBasicInfoActivity extends BaseActivity implements View.OnClickListener {
    private static final int REQUEST_CODE_CAPTURE_CROP_PHOTO = 1;
    private static final int REQUEST_CODE_PICK_CROP_PHOTO = 2;
    private static final int REQUEST_CODE_CROP_PHOTO = 3;
    public static int isRegisteredSyncCount = 0;
    private LinearLayout main_content;
    private CircleImageView mAvatarImg;
    private EditText mNameEdit;
    private TextView mSexTv,tv_man,tv_woman;
    private TextView mBirthdayTv;
    private TextView mCityTv;
    private Button mNextStepBtn;
    private LinearLayout lin_man, lin_woman;
    /* 前面页面传递进来的四个参数，都是必填 */
    private String mobilePrefix;
    private String mPhoneNum;
    private String mPassword;
    private String mSmsCode;
    // 可能empty但不会null,
    private String mInviteCode;
    private String thirdToken;
    private String thirdTokenType;
    // Temp
    private User mTempData;
    // 选择头像的数据
    private File mCurrentFile;
    private boolean isSelectAvatar;
    private Uri mNewPhotoUri;
    private String mRealPassword;
    private String dhPrivateKey, rsaPublicKey, rsaPrivateKey;

    public RegisterUserBasicInfoActivity() {
        noLoginRequired();
    }

    public static void start(
            Context ctx,
            String mobilePrefix,
            String phoneStr,
            String password,
            String smsCode,
            String inviteCode,
            String thirdToken,
            String thirdTokenType,
            String realPassword) {
        Intent intent = new Intent(ctx, RegisterUserBasicInfoActivity.class);
        intent.putExtra(RegisterActivity.EXTRA_AUTH_CODE, mobilePrefix);
        intent.putExtra(RegisterActivity.EXTRA_PHONE_NUMBER, phoneStr);
        intent.putExtra(RegisterActivity.EXTRA_INVITE_CODE, inviteCode);
        intent.putExtra(RegisterActivity.EXTRA_PASSWORD, password);
        intent.putExtra(RegisterActivity.EXTRA_SMS_CODE, smsCode);
        intent.putExtra("thirdToken", thirdToken);
        intent.putExtra("thirdTokenType", thirdTokenType);
        intent.putExtra(AppConstant.EXTRA_REAL_PASSWORD, realPassword);
        ctx.startActivity(intent);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register_user_basic_info);
        if (getIntent() != null) {
            mobilePrefix = getIntent().getStringExtra(RegisterActivity.EXTRA_AUTH_CODE);
            mPhoneNum = getIntent().getStringExtra(RegisterActivity.EXTRA_PHONE_NUMBER);
            mPassword = getIntent().getStringExtra(RegisterActivity.EXTRA_PASSWORD);
            mSmsCode = getIntent().getStringExtra(RegisterActivity.EXTRA_SMS_CODE);
            mInviteCode = getIntent().getStringExtra(RegisterActivity.EXTRA_INVITE_CODE);
            thirdToken = getIntent().getStringExtra("thirdToken");
            thirdTokenType = getIntent().getStringExtra("thirdTokenType");
            mRealPassword = getIntent().getStringExtra(AppConstant.EXTRA_REAL_PASSWORD);
        }
        // initKeyPair();
        initActionBar();
        initView();
        requestLocationCity();

        if (!TextUtils.isEmpty(thirdToken)) {
            if (TextUtils.equals(LoginActivity.THIRD_TYPE_QQ, thirdTokenType)) {
                QQHelper.requestUserInfo(mContext, thirdToken, userInfo -> {
                    mTempData.setNickName(userInfo.getNickname());
                    if (TextUtils.equals("男", userInfo.getGender())) {
                        mTempData.setSex(1);
                    } else {
                        mTempData.setSex(0);
                    }
                    String headImageUrl = userInfo.getFigureurlQq();
                    if (TextUtils.isEmpty(headImageUrl)) {
                        headImageUrl = userInfo.getFigureurlQq2();
                    }
                    if (TextUtils.isEmpty(headImageUrl)) {
                        headImageUrl = userInfo.getFigureurlQq1();
                    }
                    uploadThirdHeadImage(headImageUrl);
                });
            } else if (TextUtils.equals(LoginActivity.THIRD_TYPE_WECHAT, thirdTokenType)) {
                AsyncUtils.doAsync(this, t -> {
                    LogUtils.log(thirdToken);
                    Reporter.post("获取微信个人资料失败，", t);
                }, c -> {
                    WXUserInfo userInfo = WXHelper.requestUserInfo(thirdToken);
                    // 微信 0 未知 1男 2女 需要转换为我们自己定义的性别 0 女 1 男
                    if (userInfo.getSex() == 2) {
                        userInfo.setSex(0);
                    }
                    mTempData.setSex(userInfo.getSex());// 未知时默认为女
                    mTempData.setNickName(userInfo.getNickname());
                    // 微信头像直接上传服务器，服务器会压缩失败，导致服务器上只有原图地址，没有缩略图地址
                    c.uiThread(registerUserBasicInfoActivity -> {
                        uploadThirdHeadImage(userInfo.getHeadimgurl());
                    });
                });
            }
        }
        EventBusHelper.register(this);
    }

    private void uploadThirdHeadImage(String headImageUrl) {
        ImageLoadHelper.loadBitmapCenterCropDontAnimate(
                mContext,
                headImageUrl,
                b -> {
                    String path = FileUtil.saveBitmap(b);
                    mCurrentFile = new File(path);
                    if (mCurrentFile.exists()) {
                        isSelectAvatar = true;
                        ImageLoadHelper.showFile(
                                mContext, mCurrentFile, mAvatarImg
                        );
                    } else {
                        mCurrentFile = null;
                        ToastUtil.showToast(mContext, getString(R.string.load_avatar_failed));
                    }
                }, e -> {
                    ToastUtil.showToast(mContext, getString(R.string.load_avatar_failed));
                }
        );
        updateUI();
    }

    private void initActionBar() {
        getSupportActionBar().hide();
        findViewById(R.id.iv_title_left).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                doBack();
            }
        });
        TextView tvTitle = (TextView) findViewById(R.id.tv_title_center);
        tvTitle.setText(R.string.base_info);
    }

    private void initView() {
        main_content = findViewById(R.id.main_content);
        mAvatarImg = findViewById(R.id.avatar_img);
        mNameEdit = (EditText) findViewById(R.id.name_edit);
        mSexTv = (TextView) findViewById(R.id.sex_tv);
        tv_man = (TextView) findViewById(R.id.tv_man);
        tv_woman = (TextView) findViewById(R.id.tv_woman);
        mBirthdayTv = (TextView) findViewById(R.id.birthday_tv);
        mCityTv = (TextView) findViewById(R.id.city_tv);
        mNextStepBtn = (Button) findViewById(R.id.next_step_btn);
        lin_man = findViewById(R.id.lin_man);
        lin_woman = findViewById(R.id.lin_woman);
        ButtonColorChange.rechargeChange(this, mNextStepBtn,R.drawable.ql_l_g_bg_ripple);

        mAvatarImg.setOnClickListener(this);
        // ImageViewCompat.setImageTintList(mAvatarImg, ColorStateList.valueOf(SkinUtils.getSkin(this).getAccentColor()));
        findViewById(R.id.sex_select_rl).setOnClickListener(this);
        findViewById(R.id.birthday_select_rl).setOnClickListener(this);
        findViewById(R.id.lin_man).setOnClickListener(this);
        findViewById(R.id.lin_woman).setOnClickListener(this);
        if (coreManager.getConfig().disableLocationServer) {
            findViewById(R.id.city_select_rl).setVisibility(View.GONE);
        } else {
            findViewById(R.id.city_select_rl).setOnClickListener(this);
        }
        mNextStepBtn.setOnClickListener(this);

        updateUI();

        findViewById(R.id.img_back).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                onBackPressed();
            }
        });

        main_content.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // 点击空白区域隐藏软键盘
                InputMethodManager inputManager = (InputMethodManager) getSystemService(INPUT_METHOD_SERVICE);
                if (inputManager != null) {
                    inputManager.hideSoftInputFromWindow(findViewById(R.id.main_content).getWindowToken(), 0); //强制隐藏键盘
                }
            }
        });

        setWoman();
    }

    private void updateUI() {
        if (mTempData == null) {
            mTempData = new User();
            mTempData.setSex(1);
            mTempData.setBirthday(TimeUtils.sk_time_current_time() / 1000);
        }
        if (!TextUtils.isEmpty(mTempData.getNickName())) {
            mNameEdit.setText(mTempData.getNickName());
        }
        if (mTempData.getSex() == 1) {
            mSexTv.setText(R.string.sex_man);
        } else {
            mSexTv.setText(R.string.sex_woman);
        }
        mBirthdayTv.setText(TimeUtils.sk_time_s_long_2_str_for_birthday(mTempData.getBirthday()));
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.avatar_img:
                showSelectAvatarDialog();
                break;
            case R.id.sex_select_rl:
                showSelectSexDialog();
                break;
            case R.id.birthday_select_rl:
                showSelectBirthdayDialog();
                break;
            case R.id.city_select_rl:
                Intent intent = new Intent(RegisterUserBasicInfoActivity.this, SelectAreaActivity.class);
                intent.putExtra(SelectAreaActivity.EXTRA_AREA_PARENT_ID, Area.AREA_DATA_CHINA_ID);// 直接为中国
                intent.putExtra(SelectAreaActivity.EXTRA_AREA_TYPE, Area.AREA_TYPE_PROVINCE);
                intent.putExtra(SelectAreaActivity.EXTRA_AREA_DEEP, Area.AREA_TYPE_CITY);// 选择的深度为城市级别
                startActivityForResult(intent, 4);
                break;
            case R.id.next_step_btn:
                if (UiUtils.isNormalClick(v)) {
                    register();
                }
                break;
            case R.id.lin_man:
                setMan();
                break;
            case R.id.lin_woman:
                setWoman();
                break;
        }
    }

    private void setWoman() {
        mTempData.setSex(0);
        lin_man.setBackgroundResource(R.drawable.bg_register_sex_radius_defult);
        ButtonColorChange.rechargeChange(this, lin_woman,R.drawable.bg_register_sex_radius);
        tv_woman.setTextColor(Color.WHITE);
        tv_man.setTextColor(Color.GRAY);
    }

    private void setMan() {
        mTempData.setSex(1);
        lin_woman.setBackgroundResource(R.drawable.bg_register_sex_radius_defult);
        ButtonColorChange.rechargeChange(this, lin_man,R.drawable.bg_register_sex_radius);
        tv_man.setTextColor(Color.WHITE);
        tv_woman.setTextColor(Color.GRAY);
    }

    private void showSelectAvatarDialog() {
        String[] items = new String[]{getString(R.string.photograph), "" + getString(R.string.album)};
        AlertDialog.Builder builder = new AlertDialog.Builder(this).setTitle(R.string.select_avatar).setSingleChoiceItems(items, 0,
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                        if (which == 0) {
                            takePhoto();
                        } else {
                            selectPhoto();
                        }
                    }
                });
        builder.show();
    }

    private void takePhoto() {
        mNewPhotoUri = CameraUtil.getOutputMediaFileUri(this, CameraUtil.MEDIA_TYPE_IMAGE);
        CameraUtil.captureImage(this, mNewPhotoUri, REQUEST_CODE_CAPTURE_CROP_PHOTO);
    }

    private void selectPhoto() {
        CameraUtil.pickImageSimple(this, REQUEST_CODE_PICK_CROP_PHOTO);
    }

    private void showSelectSexDialog() {
        String[] sexs = new String[]{getString(R.string.sex_man), getString(R.string.sex_woman)};
        new AlertDialog.Builder(this).setTitle(R.string.select_sex)
                .setSingleChoiceItems(sexs, mTempData.getSex() == 1 ? 0 : 1, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        if (which == 0) {
                            mTempData.setSex(1);
                            mSexTv.setText(R.string.sex_man);
                        } else {
                            mTempData.setSex(0);
                            mSexTv.setText(R.string.sex_woman);
                        }
                        dialog.dismiss();
                    }
                }).setCancelable(true).create().show();
    }

    @SuppressWarnings("deprecation")
    private void showSelectBirthdayDialog() {
        DateSelectHelper dialog = DateSelectHelper.getInstance(RegisterUserBasicInfoActivity.this);
        dialog.setDateMin("1900-1-1");
        dialog.setDateMax(System.currentTimeMillis());
        dialog.setCurrentDate(mTempData.getBirthday() * 1000);
        dialog.setOnDateSetListener(new DateSelectHelper.OnDateResultListener() {
            @Override
            public void onDateSet(long time, String dateFromat) {
                mTempData.setBirthday(time / 1000);
                mBirthdayTv.setText(dateFromat);
            }
        });

        dialog.show();
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == REQUEST_CODE_CAPTURE_CROP_PHOTO) {
            // 拍照返回再去裁减
            if (resultCode == Activity.RESULT_OK) {
                if (mNewPhotoUri != null) {
                    Uri o = mNewPhotoUri;
                    mNewPhotoUri = CameraUtil.getOutputMediaFileUri(this, CameraUtil.MEDIA_TYPE_IMAGE);
                    CameraUtil.cropImage(this, o, mNewPhotoUri, REQUEST_CODE_CROP_PHOTO, 1, 1, 300, 300);
                } else {
                    ToastUtil.showToast(this, R.string.c_photo_album_failed);
                }
            }
        } else if (requestCode == REQUEST_CODE_PICK_CROP_PHOTO) {
            // 选择一张图片,然后立即调用裁减
            if (resultCode == Activity.RESULT_OK) {
                if (data != null) {
                    Uri o = Uri.fromFile(new File(CameraUtil.parsePickImageResult(data)));
                    mNewPhotoUri = CameraUtil.getOutputMediaFileUri(this, CameraUtil.MEDIA_TYPE_IMAGE);
                    CameraUtil.cropImage(this, o, mNewPhotoUri, REQUEST_CODE_CROP_PHOTO, 1, 1, 300, 300);
                } else {
                    ToastUtil.showToast(this, R.string.c_photo_album_failed);
                }
            }
        } else if (requestCode == REQUEST_CODE_CROP_PHOTO) {
            if (resultCode == Activity.RESULT_OK) {
                isSelectAvatar = true;
                if (mNewPhotoUri != null) {
                    mCurrentFile = new File(mNewPhotoUri.getPath());
                    AvatarHelper.getInstance().displayUrl(mNewPhotoUri.toString(), mAvatarImg);
                } else {
                    ToastUtil.showToast(this, R.string.c_crop_failed);
                }
            }
        } else if (requestCode == 4) {
            // 选择城市
            if (resultCode == RESULT_OK && data != null) {
                int countryId = data.getIntExtra(SelectAreaActivity.EXTRA_COUNTRY_ID, 0);
                int provinceId = data.getIntExtra(SelectAreaActivity.EXTRA_PROVINCE_ID, 0);
                int cityId = data.getIntExtra(SelectAreaActivity.EXTRA_CITY_ID, 0);
                int countyId = data.getIntExtra(SelectAreaActivity.EXTRA_COUNTY_ID, 0);

                String province_name = data.getStringExtra(SelectAreaActivity.EXTRA_PROVINCE_NAME);
                String city_name = data.getStringExtra(SelectAreaActivity.EXTRA_CITY_NAME);
                /*String county_name = data.getStringExtra(SelectAreaActivity.EXTRA_COUNTY_ID);*/
                mCityTv.setText(province_name + "-" + city_name);

                mTempData.setCountryId(countryId);
                mTempData.setProvinceId(provinceId);
                mTempData.setCityId(cityId);
                mTempData.setAreaId(countyId);
            }
        }
    }

    @Subscribe(threadMode = ThreadMode.MainThread)
    public void helloEventBus(MessageLogin message) {
        finish();
    }

    private void loadPageData() {
        mTempData.setNickName(mNameEdit.getText().toString().trim());
    }

    private void register() {
        loadPageData();

        if (TextUtils.isEmpty(mTempData.getNickName())) {
            mNameEdit.requestFocus();
            mNameEdit.setError(StringUtils.editTextHtmlErrorTip(this, R.string.name_empty_error));
            return;
        }

//        if (!coreManager.getConfig().disableLocationServer) {
//            if (mTempData.getCityId() <= 0) {
//                TipDialog tipDialog = new TipDialog(this);
//                tipDialog.setTip(getString(R.string.live_address_empty_error));
//                tipDialog.show();
//                return;
//            }
//        }

        if (!isSelectAvatar) {
            DialogHelper.tip(this, getString(R.string.must_select_avatar_can_register));
            return;
        }

        Map<String, String> params = new HashMap<>();

        if (MyApplication.IS_SUPPORT_SECURE_CHAT) {
            // SecureFlag 将密钥对上传服务器
            DH.DHKeyPair dhKeyPair = DH.genKeyPair();
            String dhPublicKey = dhKeyPair.getPublicKeyBase64();
            dhPrivateKey = dhKeyPair.getPrivateKeyBase64();
            String aesEncryptDHPrivateKeyResult = SecureChatUtil.aesEncryptDHPrivateKey(mRealPassword, dhPrivateKey);
            RSA.RsaKeyPair rsaKeyPair = RSA.genKeyPair();
            rsaPublicKey = rsaKeyPair.getPublicKeyBase64();
            rsaPrivateKey = rsaKeyPair.getPrivateKeyBase64();
            String aesEncryptRSAPrivateKeyResult = SecureChatUtil.aesEncryptRSAPrivateKey(mRealPassword, rsaPrivateKey);
            params.put("dhPublicKey", dhPublicKey);
            params.put("dhPrivateKey", aesEncryptDHPrivateKeyResult);
            params.put("rsaPublicKey", rsaPublicKey);
            params.put("rsaPrivateKey", aesEncryptRSAPrivateKeyResult);
        }

        // 前面页面传递的信息
        params.put("userType", "0");
        params.put("telephone", mPhoneNum);
        params.put("password", mPassword);
        params.put("smsCode", mSmsCode);
        if (!TextUtils.isEmpty(mInviteCode)) {
            params.put("inviteCode", mInviteCode);
        }
        params.put("areaCode", mobilePrefix);//TODO AreaCode 区号暂时不带
        // 本页面信息
        params.put("nickname", mTempData.getNickName());
        params.put("sex", String.valueOf(mTempData.getSex()));
        params.put("birthday", String.valueOf(mTempData.getBirthday()));
        params.put("xmppVersion", "1");
        params.put("countryId", String.valueOf(mTempData.getCountryId()));
        params.put("provinceId", String.valueOf(mTempData.getProvinceId()));
        params.put("cityId", String.valueOf(mTempData.getCityId()));
        params.put("areaId", String.valueOf(mTempData.getAreaId()));

        params.put("isSmsRegister", String.valueOf(RegisterActivity.isSmsRegister));

        // 附加信息
        params.put("apiVersion", DeviceInfoUtil.getVersionCode(mContext) + "");
        params.put("model", DeviceInfoUtil.getModel());
        params.put("osVersion", DeviceInfoUtil.getOsVersion());
        params.put("serial", DeviceInfoUtil.getDeviceId(mContext));
        // 地址信息
        double latitude = MyApplication.getInstance().getBdLocationHelper().getLatitude();
        double longitude = MyApplication.getInstance().getBdLocationHelper().getLongitude();
        String location = MyApplication.getInstance().getBdLocationHelper().getAddress();
        if (latitude != 0)
            params.put("latitude", String.valueOf(latitude));
        if (longitude != 0)
            params.put("longitude", String.valueOf(longitude));
        if (!TextUtils.isEmpty(location))
            params.put("location", location);
        DialogHelper.showDefaulteMessageProgressDialog(this);

        LoginSecureHelper.secureRegister(
                this, coreManager, thirdToken, thirdTokenType,
                params,
                t -> {
                    DialogHelper.dismissProgressDialog();
                    ToastUtil.showToast(this, this.getString(R.string.tip_login_secure_place_holder, t.getMessage()));
                }, result -> {
                    DialogHelper.dismissProgressDialog();
                    if (!com.xuan.xuanhttplibrary.okhttp.result.Result.checkSuccess(getApplicationContext(), result)) {
                        if (result == null) {
                            Reporter.post("注册失败，result为空");
                        } else {
                            Reporter.post("注册失败，" + result.toString());
                        }
                        return;
                    }
                    // 注册成功
                    boolean success = LoginHelper.setLoginUser(RegisterUserBasicInfoActivity.this, coreManager, mPhoneNum, mPassword, result);
                    if (success) {
                        isRegisteredSyncCount = 3;

                        if (MyApplication.IS_SUPPORT_SECURE_CHAT) {
                            SecureChatUtil.setDHPrivateKey(result.getData().getUserId(), dhPrivateKey);
                            SecureChatUtil.setRSAPublicKey(result.getData().getUserId(), rsaPublicKey);
                            SecureChatUtil.setRSAPrivateKey(result.getData().getUserId(), rsaPrivateKey);
                        }

                        // 新注册的账号没有支付密码，
                        MyApplication.getInstance().initPayPassword(result.getData().getUserId(), 0);
                        YeepayHelper.saveOpened(mContext, false);
                        PrivacySettingHelper.setPrivacySettings(RegisterUserBasicInfoActivity.this, result.getData().getSettings());
                        MyApplication.getInstance().initMulti();
                        if (mCurrentFile != null && mCurrentFile.exists()) {
                            // 选择了头像，那么先上传头像
                            uploadAvatar(result.getData().getIsupdate(), mCurrentFile);
                            return;
                        } else {
                            // 没有选择头像，直接进入程序主页
                            // startActivity(new Intent(RegisterUserBasicInfoActivity.this, DataDownloadActivity.class));
                            DataDownloadActivity.start(mContext, result.getData().getIsupdate(), mRealPassword);
                            finish();
                        }
                        ToastUtil.showToast(RegisterUserBasicInfoActivity.this, R.string.register_success);
                    } else {
                        // 失败
                        if (TextUtils.isEmpty(result.getResultMsg())) {
                            ToastUtil.showToast(RegisterUserBasicInfoActivity.this, R.string.register_error);
                        } else {
                            ToastUtil.showToast(RegisterUserBasicInfoActivity.this, result.getResultMsg());
                        }
                    }
                });
    }

    /**
     * 自动定位...
     */
    private void requestLocationCity() {
        MapHelper.getInstance().requestLatLng(new MapHelper.OnSuccessListener<MapHelper.LatLng>() {
            @Override
            public void onSuccess(MapHelper.LatLng latLng) {
                MapHelper.getInstance().requestCityName(latLng, new MapHelper.OnSuccessListener<String>() {
                    @Override
                    public void onSuccess(String s) {
                        String cityName = MyApplication.getInstance().getBdLocationHelper().getCityName();
                        Area area = null;
                        if (!TextUtils.isEmpty(cityName)) {
                            area = AreasDao.getInstance().searchByName(cityName);
                        }
                        if (area != null) {
                            Area countryArea = null;
                            Area provinceArea = null;
                            Area cityArea = null;
                            Area countyArea = null;
                            switch (area.getType()) {
                                case Area.AREA_TYPE_COUNTRY:
                                    countryArea = area;
                                    break;
                                case Area.AREA_TYPE_PROVINCE:
                                    provinceArea = area;
                                    break;
                                case Area.AREA_TYPE_CITY:
                                    cityArea = area;
                                    break;
                                case Area.AREA_TYPE_COUNTY:
                                default:
                                    countyArea = area;
                                    break;
                            }
                            if (countyArea != null) {
                                mTempData.setAreaId(countyArea.getId());
                                cityArea = AreasDao.getInstance().getArea(countyArea.getParent_id());
                            }

                            if (cityArea != null) {
                                mTempData.setCityId(cityArea.getId());
                                mCityTv.setText(cityArea.getName());
                                provinceArea = AreasDao.getInstance().getArea(cityArea.getParent_id());
                            }

                            if (provinceArea != null) {
                                mTempData.setProvinceId(provinceArea.getId());
                                countryArea = AreasDao.getInstance().getArea(provinceArea.getParent_id());
                            }

                            if (countryArea != null) {
                                mTempData.setCountryId(countryArea.getId());
                            }
                        } else {
                            Log.e(TAG, "获取地区失败，", new RuntimeException("找不到城市：" + cityName));
                        }
                    }
                }, new MapHelper.OnErrorListener() {
                    @Override
                    public void onError(Throwable t) {
                        Log.e(TAG, "获取城市名称失败，", t);

                    }
                });
            }
        }, new MapHelper.OnErrorListener() {
            @Override
            public void onError(Throwable t) {
                Log.e(TAG, "定位经纬度失败，", t);
            }
        });
    }

    @Override
    public void onBackPressed() {
        doBack();
    }

    @Override
    protected boolean onHomeAsUp() {
        doBack();
        return true;
    }

    private void doBack() {
        TipDialog tipDialog = new TipDialog(this);
        tipDialog.setmConfirmOnClickListener(getString(R.string.cancel_register_prompt), new TipDialog.ConfirmOnClickListener() {
            @Override
            public void confirm() {
                finish();
            }
        });
        tipDialog.show();
    }

    private void uploadAvatar(int isupdate, File file) {
        if (!file.exists()) {
            // 文件不存在
            return;
        }
        // 显示正在上传的ProgressDialog
        DialogHelper.showMessageProgressDialog(this, getString(R.string.upload_avataring));
        RequestParams params = new RequestParams();
        String loginUserId = coreManager.getSelf().getUserId();
        params.put("userId", loginUserId);
        try {
            params.put("file1", file);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        AsyncHttpClient client = new AsyncHttpClient();
        client.post(coreManager.getConfig().AVATAR_UPLOAD_URL, params, new AsyncHttpResponseHandler() {
            @Override
            public void onSuccess(int arg0, Header[] arg1, byte[] arg2) {
                boolean success = false;
                if (arg0 == 200) {
                    Result result = null;
                    try {
                        result = JSON.parseObject(new String(arg2), Result.class);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                    if (result != null && result.getResultCode() == Result.CODE_SUCCESS) {
                        success = true;
                    }
                }

                DialogHelper.dismissProgressDialog();
                if (success) {
                    ToastUtil.showToast(RegisterUserBasicInfoActivity.this, R.string.upload_avatar_success);
                } else {
                    ToastUtil.showToast(RegisterUserBasicInfoActivity.this, R.string.upload_avatar_failed);
                }

                // startActivity(new Intent(RegisterUserBasicInfoActivity.this, DataDownloadActivity.class));
                DataDownloadActivity.start(mContext, isupdate, mRealPassword);
                finish();
            }

            @Override
            public void onFailure(int arg0, Header[] arg1, byte[] arg2, Throwable arg3) {
                DialogHelper.dismissProgressDialog();
                ToastUtil.showToast(RegisterUserBasicInfoActivity.this, R.string.upload_avatar_failed);
                // startActivity(new Intent(RegisterUserBasicInfoActivity.this, DataDownloadActivity.class));
                DataDownloadActivity.start(mContext, isupdate, mRealPassword);
                finish();
            }
        });
    }
}
