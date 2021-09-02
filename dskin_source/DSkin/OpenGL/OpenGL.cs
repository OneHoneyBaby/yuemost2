namespace DSkin.OpenGL
{
    using DSkin;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class OpenGL : IDisposable
    {
        public uint FOG_SPECULAR_TEXTURE_WIN;
        public const uint GL_2_BYTES = 0x1407;
        public const uint GL_2D = 0x600;
        public const uint GL_3_BYTES = 0x1408;
        public const uint GL_3D = 0x601;
        public const uint GL_3D_COLOR_TEXTURE = 0x603;
        public const uint GL_4_BYTES = 0x1409;
        public const uint GL_4D_COLOR = 0x602;
        public const uint GL_4D_COLOR_TEXTURE = 0x604;
        public const uint GL_ACCUM = 0x100;
        public const uint GL_ACCUM_ALPHA_BITS = 0xd5b;
        public const uint GL_ACCUM_BLUE_BITS = 0xd5a;
        public const uint GL_ACCUM_BUFFER_BIT = 0x200;
        public const uint GL_ACCUM_CLEAR_VALUE = 0xb80;
        public const uint GL_ACCUM_GREEN_BITS = 0xd59;
        public const uint GL_ACCUM_RED_BITS = 0xd58;
        public const uint GL_ADD = 260;
        public const uint GL_ALL_ATTRIB_BITS = 0xfffff;
        public const uint GL_ALPHA = 0x1906;
        public const uint GL_ALPHA_BIAS = 0xd1d;
        public const uint GL_ALPHA_BITS = 0xd55;
        public const uint GL_ALPHA_SCALE = 0xd1c;
        public const uint GL_ALPHA_TEST = 0xbc0;
        public const uint GL_ALPHA_TEST_FUNC = 0xbc1;
        public const uint GL_ALPHA_TEST_REF = 0xbc2;
        public const uint GL_ALPHA12 = 0x803d;
        public const uint GL_ALPHA16 = 0x803e;
        public const uint GL_ALPHA4 = 0x803b;
        public const uint GL_ALPHA8 = 0x803c;
        public const uint GL_ALWAYS = 0x207;
        public const uint GL_AMBIENT = 0x1200;
        public const uint GL_AMBIENT_AND_DIFFUSE = 0x1602;
        public const uint GL_AND = 0x1501;
        public const uint GL_AND_INVERTED = 0x1504;
        public const uint GL_AND_REVERSE = 0x1502;
        public const uint GL_ATTRIB_STACK_DEPTH = 0xbb0;
        public const uint GL_AUTO_NORMAL = 0xd80;
        public const uint GL_AUX_BUFFERS = 0xc00;
        public const uint GL_AUX0 = 0x409;
        public const uint GL_AUX1 = 0x40a;
        public const uint GL_AUX2 = 0x40b;
        public const uint GL_AUX3 = 0x40c;
        public const uint GL_BACK = 0x405;
        public const uint GL_BACK_LEFT = 0x402;
        public const uint GL_BACK_RIGHT = 0x403;
        public const uint GL_BGR_EXT = 0x80e0;
        public const uint GL_BGRA_EXT = 0x80e1;
        public const uint GL_BITMAP = 0x1a00;
        public const uint GL_BITMAP_TOKEN = 0x704;
        public const uint GL_BLEND = 0xbe2;
        public const uint GL_BLEND_DST = 0xbe0;
        public const uint GL_BLEND_SRC = 0xbe1;
        public const uint GL_BLUE = 0x1905;
        public const uint GL_BLUE_BIAS = 0xd1b;
        public const uint GL_BLUE_BITS = 0xd54;
        public const uint GL_BLUE_SCALE = 0xd1a;
        public const uint GL_BYTE = 0x1400;
        public const uint GL_C3F_V3F = 0x2a24;
        public const uint GL_C4F_N3F_V3F = 0x2a26;
        public const uint GL_C4UB_V2F = 0x2a22;
        public const uint GL_C4UB_V3F = 0x2a23;
        public const uint GL_CCW = 0x901;
        public const uint GL_CLAMP = 0x2900;
        public const uint GL_CLEAR = 0x1500;
        public const uint GL_CLIENT_ALL_ATTRIB_BITS = uint.MaxValue;
        public const uint GL_CLIENT_ATTRIB_STACK_DEPTH = 0xbb1;
        public const uint GL_CLIENT_PIXEL_STORE_BIT = 1;
        public const uint GL_CLIENT_VERTEX_ARRAY_BIT = 2;
        public const uint GL_CLIP_PLANE0 = 0x3000;
        public const uint GL_CLIP_PLANE1 = 0x3001;
        public const uint GL_CLIP_PLANE2 = 0x3002;
        public const uint GL_CLIP_PLANE3 = 0x3003;
        public const uint GL_CLIP_PLANE4 = 0x3004;
        public const uint GL_CLIP_PLANE5 = 0x3005;
        public const uint GL_COEFF = 0xa00;
        public const uint GL_COLOR = 0x1800;
        public const uint GL_COLOR_ARRAY = 0x8076;
        public const uint GL_COLOR_ARRAY_COUNT_EXT = 0x8084;
        public const uint GL_COLOR_ARRAY_EXT = 0x8076;
        public const uint GL_COLOR_ARRAY_POINTER = 0x8090;
        public const uint GL_COLOR_ARRAY_POINTER_EXT = 0x8090;
        public const uint GL_COLOR_ARRAY_SIZE = 0x8081;
        public const uint GL_COLOR_ARRAY_SIZE_EXT = 0x8081;
        public const uint GL_COLOR_ARRAY_STRIDE = 0x8083;
        public const uint GL_COLOR_ARRAY_STRIDE_EXT = 0x8083;
        public const uint GL_COLOR_ARRAY_TYPE = 0x8082;
        public const uint GL_COLOR_ARRAY_TYPE_EXT = 0x8082;
        public const uint GL_COLOR_BUFFER_BIT = 0x4000;
        public const uint GL_COLOR_CLEAR_VALUE = 0xc22;
        public const uint GL_COLOR_INDEX = 0x1900;
        public const uint GL_COLOR_INDEX1_EXT = 0x80e2;
        public const uint GL_COLOR_INDEX12_EXT = 0x80e6;
        public const uint GL_COLOR_INDEX16_EXT = 0x80e7;
        public const uint GL_COLOR_INDEX2_EXT = 0x80e3;
        public const uint GL_COLOR_INDEX4_EXT = 0x80e4;
        public const uint GL_COLOR_INDEX8_EXT = 0x80e5;
        public const uint GL_COLOR_INDEXES = 0x1603;
        public const uint GL_COLOR_LOGIC_OP = 0xbf2;
        public const uint GL_COLOR_MATERIAL = 0xb57;
        public const uint GL_COLOR_MATERIAL_FACE = 0xb55;
        public const uint GL_COLOR_MATERIAL_PARAMETER = 0xb56;
        public const uint GL_COLOR_TABLE_ALPHA_SIZE_EXT = 0x80dd;
        public const uint GL_COLOR_TABLE_BLUE_SIZE_EXT = 0x80dc;
        public const uint GL_COLOR_TABLE_FORMAT_EXT = 0x80d8;
        public const uint GL_COLOR_TABLE_GREEN_SIZE_EXT = 0x80db;
        public const uint GL_COLOR_TABLE_INTENSITY_SIZE_EXT = 0x80df;
        public const uint GL_COLOR_TABLE_LUMINANCE_SIZE_EXT = 0x80de;
        public const uint GL_COLOR_TABLE_RED_SIZE_EXT = 0x80da;
        public const uint GL_COLOR_TABLE_WIDTH_EXT = 0x80d9;
        public const uint GL_COLOR_WRITEMASK = 0xc23;
        public const uint GL_COMPILE = 0x1300;
        public const uint GL_COMPILE_AND_EXECUTE = 0x1301;
        public const uint GL_CONSTANT_ATTENUATION = 0x1207;
        public const uint GL_COPY = 0x1503;
        public const uint GL_COPY_INVERTED = 0x150c;
        public const uint GL_COPY_PIXEL_TOKEN = 0x706;
        public const uint GL_CULL_FACE = 0xb44;
        public const uint GL_CULL_FACE_MODE = 0xb45;
        public const uint GL_CURRENT_BIT = 1;
        public const uint GL_CURRENT_COLOR = 0xb00;
        public const uint GL_CURRENT_INDEX = 0xb01;
        public const uint GL_CURRENT_NORMAL = 0xb02;
        public const uint GL_CURRENT_RASTER_COLOR = 0xb04;
        public const uint GL_CURRENT_RASTER_DISTANCE = 0xb09;
        public const uint GL_CURRENT_RASTER_INDEX = 0xb05;
        public const uint GL_CURRENT_RASTER_POSITION = 0xb07;
        public const uint GL_CURRENT_RASTER_POSITION_VALID = 0xb08;
        public const uint GL_CURRENT_RASTER_TEXTURE_COORDS = 0xb06;
        public const uint GL_CURRENT_TEXTURE_COORDS = 0xb03;
        public const uint GL_CW = 0x900;
        public const uint GL_DECAL = 0x2101;
        public const uint GL_DECR = 0x1e03;
        public const uint GL_DEPTH = 0x1801;
        public const uint GL_DEPTH_BIAS = 0xd1f;
        public const uint GL_DEPTH_BITS = 0xd56;
        public const uint GL_DEPTH_BUFFER_BIT = 0x100;
        public const uint GL_DEPTH_CLEAR_VALUE = 0xb73;
        public const uint GL_DEPTH_COMPONENT = 0x1902;
        public const uint GL_DEPTH_FUNC = 0xb74;
        public const uint GL_DEPTH_RANGE = 0xb70;
        public const uint GL_DEPTH_SCALE = 0xd1e;
        public const uint GL_DEPTH_TEST = 0xb71;
        public const uint GL_DEPTH_WRITEMASK = 0xb72;
        public const uint GL_DIFFUSE = 0x1201;
        public const uint GL_DITHER = 0xbd0;
        public const uint GL_DOMAIN = 0xa02;
        public const uint GL_DONT_CARE = 0x1100;
        public const uint GL_DOUBLE = 0x140a;
        public const uint GL_DOUBLE_EXT = 1;
        public const uint GL_DOUBLEBUFFER = 0xc32;
        public const uint GL_DRAW_BUFFER = 0xc01;
        public const uint GL_DRAW_PIXEL_TOKEN = 0x705;
        public const uint GL_DST_ALPHA = 0x304;
        public const uint GL_DST_COLOR = 0x306;
        public const uint GL_EDGE_FLAG = 0xb43;
        public const uint GL_EDGE_FLAG_ARRAY = 0x8079;
        public const uint GL_EDGE_FLAG_ARRAY_COUNT_EXT = 0x808d;
        public const uint GL_EDGE_FLAG_ARRAY_EXT = 0x8079;
        public const uint GL_EDGE_FLAG_ARRAY_POINTER = 0x8093;
        public const uint GL_EDGE_FLAG_ARRAY_POINTER_EXT = 0x8093;
        public const uint GL_EDGE_FLAG_ARRAY_STRIDE = 0x808c;
        public const uint GL_EDGE_FLAG_ARRAY_STRIDE_EXT = 0x808c;
        public const uint GL_EMISSION = 0x1600;
        public const uint GL_ENABLE_BIT = 0x2000;
        public const uint GL_EQUAL = 0x202;
        public const uint GL_EQUIV = 0x1509;
        public const uint GL_EVAL_BIT = 0x10000;
        public const uint GL_EXP = 0x800;
        public const uint GL_EXP2 = 0x801;
        public const uint GL_EXT_bgra = 1;
        public const uint GL_EXT_paletted_texture = 1;
        public const uint GL_EXT_vertex_array = 1;
        public const uint GL_EXTENSIONS = 0x1f03;
        public const uint GL_EYE_LINEAR = 0x2400;
        public const uint GL_EYE_PLANE = 0x2502;
        public const uint GL_FALSE = 0;
        public const uint GL_FASTEST = 0x1101;
        public const uint GL_FEEDBACK = 0x1c01;
        public const uint GL_FEEDBACK_BUFFER_POINTER = 0xdf0;
        public const uint GL_FEEDBACK_BUFFER_SIZE = 0xdf1;
        public const uint GL_FEEDBACK_BUFFER_TYPE = 0xdf2;
        public const uint GL_FILL = 0x1b02;
        public const uint GL_FLAT = 0x1d00;
        public const uint GL_FLOAT = 0x1406;
        public const uint GL_FOG = 0xb60;
        public const uint GL_FOG_BIT = 0x80;
        public const uint GL_FOG_COLOR = 0xb66;
        public const uint GL_FOG_DENSITY = 0xb62;
        public const uint GL_FOG_END = 0xb64;
        public const uint GL_FOG_HINT = 0xc54;
        public const uint GL_FOG_INDEX = 0xb61;
        public const uint GL_FOG_MODE = 0xb65;
        public const uint GL_FOG_START = 0xb63;
        public const uint GL_FRONT = 0x404;
        public const uint GL_FRONT_AND_BACK = 0x408;
        public const uint GL_FRONT_FACE = 0xb46;
        public const uint GL_FRONT_LEFT = 0x400;
        public const uint GL_FRONT_RIGHT = 0x401;
        public const uint GL_GEQUAL = 0x206;
        public const uint GL_GREATER = 0x204;
        public const uint GL_GREEN = 0x1904;
        public const uint GL_GREEN_BIAS = 0xd19;
        public const uint GL_GREEN_BITS = 0xd53;
        public const uint GL_GREEN_SCALE = 0xd18;
        public const uint GL_HINT_BIT = 0x8000;
        public const uint GL_INCR = 0x1e02;
        public const uint GL_INDEX_ARRAY = 0x8077;
        public const uint GL_INDEX_ARRAY_COUNT_EXT = 0x8087;
        public const uint GL_INDEX_ARRAY_EXT = 0x8077;
        public const uint GL_INDEX_ARRAY_POINTER = 0x8091;
        public const uint GL_INDEX_ARRAY_POINTER_EXT = 0x8091;
        public const uint GL_INDEX_ARRAY_STRIDE = 0x8086;
        public const uint GL_INDEX_ARRAY_STRIDE_EXT = 0x8086;
        public const uint GL_INDEX_ARRAY_TYPE = 0x8085;
        public const uint GL_INDEX_ARRAY_TYPE_EXT = 0x8085;
        public const uint GL_INDEX_BITS = 0xd51;
        public const uint GL_INDEX_CLEAR_VALUE = 0xc20;
        public const uint GL_INDEX_LOGIC_OP = 0xbf1;
        public const uint GL_INDEX_MODE = 0xc30;
        public const uint GL_INDEX_OFFSET = 0xd13;
        public const uint GL_INDEX_SHIFT = 0xd12;
        public const uint GL_INDEX_WRITEMASK = 0xc21;
        public const uint GL_INT = 0x1404;
        public const uint GL_INTENSITY = 0x8049;
        public const uint GL_INTENSITY12 = 0x804c;
        public const uint GL_INTENSITY16 = 0x804d;
        public const uint GL_INTENSITY4 = 0x804a;
        public const uint GL_INTENSITY8 = 0x804b;
        public const uint GL_INVALID_ENUM = 0x500;
        public const uint GL_INVALID_OPERATION = 0x502;
        public const uint GL_INVALID_VALUE = 0x501;
        public const uint GL_INVERT = 0x150a;
        public const uint GL_KEEP = 0x1e00;
        public const uint GL_LEFT = 0x406;
        public const uint GL_LEQUAL = 0x203;
        public const uint GL_LESS = 0x201;
        public const uint GL_LIGHT_MODEL_AMBIENT = 0xb53;
        public const uint GL_LIGHT_MODEL_LOCAL_VIEWER = 0xb51;
        public const uint GL_LIGHT_MODEL_TWO_SIDE = 0xb52;
        public const uint GL_LIGHT0 = 0x4000;
        public const uint GL_LIGHT1 = 0x4001;
        public const uint GL_LIGHT2 = 0x4002;
        public const uint GL_LIGHT3 = 0x4003;
        public const uint GL_LIGHT4 = 0x4004;
        public const uint GL_LIGHT5 = 0x4005;
        public const uint GL_LIGHT6 = 0x4006;
        public const uint GL_LIGHT7 = 0x4007;
        public const uint GL_LIGHTING = 0xb50;
        public const uint GL_LIGHTING_BIT = 0x40;
        public const uint GL_LINE = 0x1b01;
        public const uint GL_LINE_BIT = 4;
        public const uint GL_LINE_LOOP = 2;
        public const uint GL_LINE_RESET_TOKEN = 0x707;
        public const uint GL_LINE_SMOOTH = 0xb20;
        public const uint GL_LINE_SMOOTH_HINT = 0xc52;
        public const uint GL_LINE_STIPPLE = 0xb24;
        public const uint GL_LINE_STIPPLE_PATTERN = 0xb25;
        public const uint GL_LINE_STIPPLE_REPEAT = 0xb26;
        public const uint GL_LINE_STRIP = 3;
        public const uint GL_LINE_TOKEN = 0x702;
        public const uint GL_LINE_WIDTH = 0xb21;
        public const uint GL_LINE_WIDTH_GRANULARITY = 0xb23;
        public const uint GL_LINE_WIDTH_RANGE = 0xb22;
        public const uint GL_LINEAR = 0x2601;
        public const uint GL_LINEAR_ATTENUATION = 0x1208;
        public const uint GL_LINEAR_MIPMAP_LINEAR = 0x2703;
        public const uint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
        public const uint GL_LINES = 1;
        public const uint GL_LIST_BASE = 0xb32;
        public const uint GL_LIST_BIT = 0x20000;
        public const uint GL_LIST_INDEX = 0xb33;
        public const uint GL_LIST_MODE = 0xb30;
        public const uint GL_LOAD = 0x101;
        public const uint GL_LOGIC_OP_MODE = 0xbf0;
        public const uint GL_LUMINANCE = 0x1909;
        public const uint GL_LUMINANCE_ALPHA = 0x190a;
        public const uint GL_LUMINANCE12 = 0x8041;
        public const uint GL_LUMINANCE12_ALPHA12 = 0x8047;
        public const uint GL_LUMINANCE12_ALPHA4 = 0x8046;
        public const uint GL_LUMINANCE16 = 0x8042;
        public const uint GL_LUMINANCE16_ALPHA16 = 0x8048;
        public const uint GL_LUMINANCE4 = 0x803f;
        public const uint GL_LUMINANCE4_ALPHA4 = 0x8043;
        public const uint GL_LUMINANCE6_ALPHA2 = 0x8044;
        public const uint GL_LUMINANCE8 = 0x8040;
        public const uint GL_LUMINANCE8_ALPHA8 = 0x8045;
        public const uint GL_MAP_COLOR = 0xd10;
        public const uint GL_MAP_STENCIL = 0xd11;
        public const uint GL_MAP1_COLOR_4 = 0xd90;
        public const uint GL_MAP1_GRID_DOMAIN = 0xdd0;
        public const uint GL_MAP1_GRID_SEGMENTS = 0xdd1;
        public const uint GL_MAP1_INDEX = 0xd91;
        public const uint GL_MAP1_NORMAL = 0xd92;
        public const uint GL_MAP1_TEXTURE_COORD_1 = 0xd93;
        public const uint GL_MAP1_TEXTURE_COORD_2 = 0xd94;
        public const uint GL_MAP1_TEXTURE_COORD_3 = 0xd95;
        public const uint GL_MAP1_TEXTURE_COORD_4 = 0xd96;
        public const uint GL_MAP1_VERTEX_3 = 0xd97;
        public const uint GL_MAP1_VERTEX_4 = 0xd98;
        public const uint GL_MAP2_COLOR_4 = 0xdb0;
        public const uint GL_MAP2_GRID_DOMAIN = 0xdd2;
        public const uint GL_MAP2_GRID_SEGMENTS = 0xdd3;
        public const uint GL_MAP2_INDEX = 0xdb1;
        public const uint GL_MAP2_NORMAL = 0xdb2;
        public const uint GL_MAP2_TEXTURE_COORD_1 = 0xdb3;
        public const uint GL_MAP2_TEXTURE_COORD_2 = 0xdb4;
        public const uint GL_MAP2_TEXTURE_COORD_3 = 0xdb5;
        public const uint GL_MAP2_TEXTURE_COORD_4 = 0xdb6;
        public const uint GL_MAP2_VERTEX_3 = 0xdb7;
        public const uint GL_MAP2_VERTEX_4 = 0xdb8;
        public const uint GL_MATRIX_MODE = 0xba0;
        public const uint GL_MAX_ATTRIB_STACK_DEPTH = 0xd35;
        public const uint GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 0xd3b;
        public const uint GL_MAX_CLIP_PLANES = 0xd32;
        public const uint GL_MAX_ELEMENTS_INDICES_WIN = 0x80e9;
        public const uint GL_MAX_ELEMENTS_VERTICES_WIN = 0x80e8;
        public const uint GL_MAX_EVAL_ORDER = 0xd30;
        public const uint GL_MAX_LIGHTS = 0xd31;
        public const uint GL_MAX_LIST_NESTING = 0xb31;
        public const uint GL_MAX_MODELVIEW_STACK_DEPTH = 0xd36;
        public const uint GL_MAX_NAME_STACK_DEPTH = 0xd37;
        public const uint GL_MAX_PIXEL_MAP_TABLE = 0xd34;
        public const uint GL_MAX_PROJECTION_STACK_DEPTH = 0xd38;
        public const uint GL_MAX_TEXTURE_SIZE = 0xd33;
        public const uint GL_MAX_TEXTURE_STACK_DEPTH = 0xd39;
        public const uint GL_MAX_VIEWPORT_DIMS = 0xd3a;
        public const uint GL_MODELVIEW = 0x1700;
        public const uint GL_MODELVIEW_MATRIX = 0xba6;
        public const uint GL_MODELVIEW_STACK_DEPTH = 0xba3;
        public const uint GL_MODULATE = 0x2100;
        public const uint GL_MULT = 0x103;
        public const uint GL_N3F_V3F = 0x2a25;
        public const uint GL_NAME_STACK_DEPTH = 0xd70;
        public const uint GL_NAND = 0x150e;
        public const uint GL_NEAREST = 0x2600;
        public const uint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
        public const uint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
        public const uint GL_NEVER = 0x200;
        public const uint GL_NICEST = 0x1102;
        public const uint GL_NO_ERROR = 0;
        public const uint GL_NONE = 0;
        public const uint GL_NOOP = 0x1505;
        public const uint GL_NOR = 0x1508;
        public const uint GL_NORMAL_ARRAY = 0x8075;
        public const uint GL_NORMAL_ARRAY_COUNT_EXT = 0x8080;
        public const uint GL_NORMAL_ARRAY_EXT = 0x8075;
        public const uint GL_NORMAL_ARRAY_POINTER = 0x808f;
        public const uint GL_NORMAL_ARRAY_POINTER_EXT = 0x808f;
        public const uint GL_NORMAL_ARRAY_STRIDE = 0x807f;
        public const uint GL_NORMAL_ARRAY_STRIDE_EXT = 0x807f;
        public const uint GL_NORMAL_ARRAY_TYPE = 0x807e;
        public const uint GL_NORMAL_ARRAY_TYPE_EXT = 0x807e;
        public const uint GL_NORMALIZE = 0xba1;
        public const uint GL_NOTEQUAL = 0x205;
        public const uint GL_OBJECT_LINEAR = 0x2401;
        public const uint GL_OBJECT_PLANE = 0x2501;
        public const uint GL_ONE = 1;
        public const uint GL_ONE_MINUS_DST_ALPHA = 0x305;
        public const uint GL_ONE_MINUS_DST_COLOR = 0x307;
        public const uint GL_ONE_MINUS_SRC_ALPHA = 0x303;
        public const uint GL_ONE_MINUS_SRC_COLOR = 0x301;
        public const uint GL_OR = 0x1507;
        public const uint GL_OR_INVERTED = 0x150d;
        public const uint GL_OR_REVERSE = 0x150b;
        public const uint GL_ORDER = 0xa01;
        public const uint GL_OUT_OF_MEMORY = 0x505;
        public const uint GL_PACK_ALIGNMENT = 0xd05;
        public const uint GL_PACK_LSB_FIRST = 0xd01;
        public const uint GL_PACK_ROW_LENGTH = 0xd02;
        public const uint GL_PACK_SKIP_PIXELS = 0xd04;
        public const uint GL_PACK_SKIP_ROWS = 0xd03;
        public const uint GL_PACK_SWAP_BYTES = 0xd00;
        public const uint GL_PASS_THROUGH_TOKEN = 0x700;
        public const uint GL_PERSPECTIVE_CORRECTION_HINT = 0xc50;
        public const uint GL_PHONG_HINT_WIN = 0x80eb;
        public const uint GL_PHONG_WIN = 0x80ea;
        public const uint GL_PIXEL_MAP_A_TO_A = 0xc79;
        public const uint GL_PIXEL_MAP_A_TO_A_SIZE = 0xcb9;
        public const uint GL_PIXEL_MAP_B_TO_B = 0xc78;
        public const uint GL_PIXEL_MAP_B_TO_B_SIZE = 0xcb8;
        public const uint GL_PIXEL_MAP_G_TO_G = 0xc77;
        public const uint GL_PIXEL_MAP_G_TO_G_SIZE = 0xcb7;
        public const uint GL_PIXEL_MAP_I_TO_A = 0xc75;
        public const uint GL_PIXEL_MAP_I_TO_A_SIZE = 0xcb5;
        public const uint GL_PIXEL_MAP_I_TO_B = 0xc74;
        public const uint GL_PIXEL_MAP_I_TO_B_SIZE = 0xcb4;
        public const uint GL_PIXEL_MAP_I_TO_G = 0xc73;
        public const uint GL_PIXEL_MAP_I_TO_G_SIZE = 0xcb3;
        public const uint GL_PIXEL_MAP_I_TO_I = 0xc70;
        public const uint GL_PIXEL_MAP_I_TO_I_SIZE = 0xcb0;
        public const uint GL_PIXEL_MAP_I_TO_R = 0xc72;
        public const uint GL_PIXEL_MAP_I_TO_R_SIZE = 0xcb2;
        public const uint GL_PIXEL_MAP_R_TO_R = 0xc76;
        public const uint GL_PIXEL_MAP_R_TO_R_SIZE = 0xcb6;
        public const uint GL_PIXEL_MAP_S_TO_S = 0xc71;
        public const uint GL_PIXEL_MAP_S_TO_S_SIZE = 0xcb1;
        public const uint GL_PIXEL_MODE_BIT = 0x20;
        public const uint GL_POINT = 0x1b00;
        public const uint GL_POINT_BIT = 2;
        public const uint GL_POINT_SIZE = 0xb11;
        public const uint GL_POINT_SIZE_GRANULARITY = 0xb13;
        public const uint GL_POINT_SIZE_RANGE = 0xb12;
        public const uint GL_POINT_SMOOTH = 0xb10;
        public const uint GL_POINT_SMOOTH_HINT = 0xc51;
        public const uint GL_POINT_TOKEN = 0x701;
        public const uint GL_POINTS = 0;
        public const uint GL_POLYGON = 9;
        public const uint GL_POLYGON_BIT = 8;
        public const uint GL_POLYGON_MODE = 0xb40;
        public const uint GL_POLYGON_OFFSET_FACTOR = 0x8038;
        public const uint GL_POLYGON_OFFSET_FILL = 0x8037;
        public const uint GL_POLYGON_OFFSET_LINE = 0x2a02;
        public const uint GL_POLYGON_OFFSET_POINT = 0x2a01;
        public const uint GL_POLYGON_OFFSET_UNITS = 0x2a00;
        public const uint GL_POLYGON_SMOOTH = 0xb41;
        public const uint GL_POLYGON_SMOOTH_HINT = 0xc53;
        public const uint GL_POLYGON_STIPPLE = 0xb42;
        public const uint GL_POLYGON_STIPPLE_BIT = 0x10;
        public const uint GL_POLYGON_TOKEN = 0x703;
        public const uint GL_POSITION = 0x1203;
        public const uint GL_PROJECTION = 0x1701;
        public const uint GL_PROJECTION_MATRIX = 0xba7;
        public const uint GL_PROJECTION_STACK_DEPTH = 0xba4;
        public const uint GL_PROXY_TEXTURE_1D = 0x8063;
        public const uint GL_PROXY_TEXTURE_2D = 0x8064;
        public const uint GL_Q = 0x2003;
        public const uint GL_QUAD_STRIP = 8;
        public const uint GL_QUADRATIC_ATTENUATION = 0x1209;
        public const uint GL_QUADS = 7;
        public const uint GL_R = 0x2002;
        public const uint GL_R3_G3_B2 = 0x2a10;
        public const uint GL_READ_BUFFER = 0xc02;
        public const uint GL_RED = 0x1903;
        public const uint GL_RED_BIAS = 0xd15;
        public const uint GL_RED_BITS = 0xd52;
        public const uint GL_RED_SCALE = 0xd14;
        public const uint GL_RENDER = 0x1c00;
        public const uint GL_RENDER_MODE = 0xc40;
        public const uint GL_RENDERER = 0x1f01;
        public const uint GL_REPEAT = 0x2901;
        public const uint GL_REPLACE = 0x1e01;
        public const uint GL_RETURN = 0x102;
        public const uint GL_RGB = 0x1907;
        public const uint GL_RGB10 = 0x8052;
        public const uint GL_RGB10_A2 = 0x8059;
        public const uint GL_RGB12 = 0x8053;
        public const uint GL_RGB16 = 0x8054;
        public const uint GL_RGB4 = 0x804f;
        public const uint GL_RGB5 = 0x8050;
        public const uint GL_RGB5_A1 = 0x8057;
        public const uint GL_RGB8 = 0x8051;
        public const uint GL_RGBA = 0x1908;
        public const uint GL_RGBA_MODE = 0xc31;
        public const uint GL_RGBA12 = 0x805a;
        public const uint GL_RGBA16 = 0x805b;
        public const uint GL_RGBA2 = 0x8055;
        public const uint GL_RGBA4 = 0x8056;
        public const uint GL_RGBA8 = 0x8058;
        public const uint GL_RIGHT = 0x407;
        public const uint GL_S = 0x2000;
        public const uint GL_SCISSOR_BIT = 0x80000;
        public const uint GL_SCISSOR_BOX = 0xc10;
        public const uint GL_SCISSOR_TEST = 0xc11;
        public const uint GL_SELECT = 0x1c02;
        public const uint GL_SELECTION_BUFFER_POINTER = 0xdf3;
        public const uint GL_SELECTION_BUFFER_SIZE = 0xdf4;
        public const uint GL_SET = 0x150f;
        public const uint GL_SHADE_MODEL = 0xb54;
        public const uint GL_SHININESS = 0x1601;
        public const uint GL_SHORT = 0x1402;
        public const uint GL_SMOOTH = 0x1d01;
        public const uint GL_SPECULAR = 0x1202;
        public const uint GL_SPHERE_MAP = 0x2402;
        public const uint GL_SPOT_CUTOFF = 0x1206;
        public const uint GL_SPOT_DIRECTION = 0x1204;
        public const uint GL_SPOT_EXPONENT = 0x1205;
        public const uint GL_SRC_ALPHA = 770;
        public const uint GL_SRC_ALPHA_SATURATE = 0x308;
        public const uint GL_SRC_COLOR = 0x300;
        public const uint GL_STACK_OVERFLOW = 0x503;
        public const uint GL_STACK_UNDERFLOW = 0x504;
        public const uint GL_STENCIL = 0x1802;
        public const uint GL_STENCIL_BITS = 0xd57;
        public const uint GL_STENCIL_BUFFER_BIT = 0x400;
        public const uint GL_STENCIL_CLEAR_VALUE = 0xb91;
        public const uint GL_STENCIL_FAIL = 0xb94;
        public const uint GL_STENCIL_FUNC = 0xb92;
        public const uint GL_STENCIL_INDEX = 0x1901;
        public const uint GL_STENCIL_PASS_DEPTH_FAIL = 0xb95;
        public const uint GL_STENCIL_PASS_DEPTH_PASS = 0xb96;
        public const uint GL_STENCIL_REF = 0xb97;
        public const uint GL_STENCIL_TEST = 0xb90;
        public const uint GL_STENCIL_VALUE_MASK = 0xb93;
        public const uint GL_STENCIL_WRITEMASK = 0xb98;
        public const uint GL_STEREO = 0xc33;
        public const uint GL_SUBPIXEL_BITS = 0xd50;
        public const uint GL_T = 0x2001;
        public const uint GL_T2F_C3F_V3F = 0x2a2a;
        public const uint GL_T2F_C4F_N3F_V3F = 0x2a2c;
        public const uint GL_T2F_C4UB_V3F = 0x2a29;
        public const uint GL_T2F_N3F_V3F = 0x2a2b;
        public const uint GL_T2F_V3F = 0x2a27;
        public const uint GL_T4F_C4F_N3F_V4F = 0x2a2d;
        public const uint GL_T4F_V4F = 0x2a28;
        public const uint GL_TEXTURE = 0x1702;
        public const uint GL_TEXTURE_1D = 0xde0;
        public const uint GL_TEXTURE_2D = 0xde1;
        public const uint GL_TEXTURE_ALPHA_SIZE = 0x805f;
        public const uint GL_TEXTURE_BINDING_1D = 0x8068;
        public const uint GL_TEXTURE_BINDING_2D = 0x8069;
        public const uint GL_TEXTURE_BIT = 0x40000;
        public const uint GL_TEXTURE_BLUE_SIZE = 0x805e;
        public const uint GL_TEXTURE_BORDER = 0x1005;
        public const uint GL_TEXTURE_BORDER_COLOR = 0x1004;
        public const uint GL_TEXTURE_COORD_ARRAY = 0x8078;
        public const uint GL_TEXTURE_COORD_ARRAY_COUNT_EXT = 0x808b;
        public const uint GL_TEXTURE_COORD_ARRAY_EXT = 0x8078;
        public const uint GL_TEXTURE_COORD_ARRAY_POINTER = 0x8092;
        public const uint GL_TEXTURE_COORD_ARRAY_POINTER_EXT = 0x8092;
        public const uint GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088;
        public const uint GL_TEXTURE_COORD_ARRAY_SIZE_EXT = 0x8088;
        public const uint GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808a;
        public const uint GL_TEXTURE_COORD_ARRAY_STRIDE_EXT = 0x808a;
        public const uint GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089;
        public const uint GL_TEXTURE_COORD_ARRAY_TYPE_EXT = 0x8089;
        public const uint GL_TEXTURE_ENV = 0x2300;
        public const uint GL_TEXTURE_ENV_COLOR = 0x2201;
        public const uint GL_TEXTURE_ENV_MODE = 0x2200;
        public const uint GL_TEXTURE_GEN_MODE = 0x2500;
        public const uint GL_TEXTURE_GEN_Q = 0xc63;
        public const uint GL_TEXTURE_GEN_R = 0xc62;
        public const uint GL_TEXTURE_GEN_S = 0xc60;
        public const uint GL_TEXTURE_GEN_T = 0xc61;
        public const uint GL_TEXTURE_GREEN_SIZE = 0x805d;
        public const uint GL_TEXTURE_HEIGHT = 0x1001;
        public const uint GL_TEXTURE_INTENSITY_SIZE = 0x8061;
        public const uint GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
        public const uint GL_TEXTURE_LUMINANCE_SIZE = 0x8060;
        public const uint GL_TEXTURE_MAG_FILTER = 0x2800;
        public const uint GL_TEXTURE_MATRIX = 0xba8;
        public const uint GL_TEXTURE_MIN_FILTER = 0x2801;
        public const uint GL_TEXTURE_PRIORITY = 0x8066;
        public const uint GL_TEXTURE_RED_SIZE = 0x805c;
        public const uint GL_TEXTURE_RESIDENT = 0x8067;
        public const uint GL_TEXTURE_STACK_DEPTH = 0xba5;
        public const uint GL_TEXTURE_WIDTH = 0x1000;
        public const uint GL_TEXTURE_WRAP_S = 0x2802;
        public const uint GL_TEXTURE_WRAP_T = 0x2803;
        public const uint GL_TRANSFORM_BIT = 0x1000;
        public const uint GL_TRIANGLE_FAN = 6;
        public const uint GL_TRIANGLE_STRIP = 5;
        public const uint GL_TRIANGLES = 4;
        public const uint GL_TRUE = 1;
        public const uint GL_UNPACK_ALIGNMENT = 0xcf5;
        public const uint GL_UNPACK_LSB_FIRST = 0xcf1;
        public const uint GL_UNPACK_ROW_LENGTH = 0xcf2;
        public const uint GL_UNPACK_SKIP_PIXELS = 0xcf4;
        public const uint GL_UNPACK_SKIP_ROWS = 0xcf3;
        public const uint GL_UNPACK_SWAP_BYTES = 0xcf0;
        public const uint GL_UNSIGNED_BYTE = 0x1401;
        public const uint GL_UNSIGNED_INT = 0x1405;
        public const uint GL_UNSIGNED_SHORT = 0x1403;
        public const uint GL_V2F = 0x2a20;
        public const uint GL_V3F = 0x2a21;
        public const uint GL_VENDOR = 0x1f00;
        public const uint GL_VERSION = 0x1f02;
        public const uint GL_VERSION_1_1 = 1;
        public const uint GL_VERTEX_ARRAY = 0x8074;
        public const uint GL_VERTEX_ARRAY_COUNT_EXT = 0x807d;
        public const uint GL_VERTEX_ARRAY_EXT = 0x8074;
        public const uint GL_VERTEX_ARRAY_POINTER = 0x808e;
        public const uint GL_VERTEX_ARRAY_POINTER_EXT = 0x808e;
        public const uint GL_VERTEX_ARRAY_SIZE = 0x807a;
        public const uint GL_VERTEX_ARRAY_SIZE_EXT = 0x807a;
        public const uint GL_VERTEX_ARRAY_STRIDE = 0x807c;
        public const uint GL_VERTEX_ARRAY_STRIDE_EXT = 0x807c;
        public const uint GL_VERTEX_ARRAY_TYPE = 0x807b;
        public const uint GL_VERTEX_ARRAY_TYPE_EXT = 0x807b;
        public const uint GL_VIEWPORT = 0xba2;
        public const uint GL_VIEWPORT_BIT = 0x800;
        public const uint GL_WIN_draw_range_elements = 1;
        public const uint GL_WIN_swap_hint = 1;
        public const uint GL_XOR = 0x1506;
        public const uint GL_ZERO = 0;
        public const uint GL_ZOOM_X = 0xd16;
        public const uint GL_ZOOM_Y = 0xd17;
        public const uint GLU_AUTO_LOAD_MATRIX = 0x18768;
        public const uint GLU_CULLING = 0x18769;
        public const uint GLU_DISPLAY_MODE = 0x1876c;
        public const uint GLU_DOMAIN_DISTANCE = 0x18779;
        public const uint GLU_EXTENSIONS = 0x189c1;
        public const uint GLU_FALSE = 0;
        public const uint GLU_FILL = 0x186ac;
        public const uint GLU_FLAT = 0x186a1;
        public const uint GLU_INCOMPATIBLE_GL_VERSION = 0x18a27;
        public const uint GLU_INSIDE = 0x186b5;
        public const uint GLU_INVALID_ENUM = 0x18a24;
        public const uint GLU_INVALID_VALUE = 0x18a25;
        public const uint GLU_LINE = 0x186ab;
        public const uint GLU_MAP1_TRIM_2 = 0x18772;
        public const uint GLU_MAP1_TRIM_3 = 0x18773;
        public const uint GLU_NONE = 0x186a2;
        public const uint GLU_NURBS_ERROR1 = 0x1879b;
        public const uint GLU_NURBS_ERROR10 = 0x187a4;
        public const uint GLU_NURBS_ERROR11 = 0x187a5;
        public const uint GLU_NURBS_ERROR12 = 0x187a6;
        public const uint GLU_NURBS_ERROR13 = 0x187a7;
        public const uint GLU_NURBS_ERROR14 = 0x187a8;
        public const uint GLU_NURBS_ERROR15 = 0x187a9;
        public const uint GLU_NURBS_ERROR16 = 0x187aa;
        public const uint GLU_NURBS_ERROR17 = 0x187ab;
        public const uint GLU_NURBS_ERROR18 = 0x187ac;
        public const uint GLU_NURBS_ERROR19 = 0x187ad;
        public const uint GLU_NURBS_ERROR2 = 0x1879c;
        public const uint GLU_NURBS_ERROR20 = 0x187ae;
        public const uint GLU_NURBS_ERROR21 = 0x187af;
        public const uint GLU_NURBS_ERROR22 = 0x187b0;
        public const uint GLU_NURBS_ERROR23 = 0x187b1;
        public const uint GLU_NURBS_ERROR24 = 0x187b2;
        public const uint GLU_NURBS_ERROR25 = 0x187b3;
        public const uint GLU_NURBS_ERROR26 = 0x187b4;
        public const uint GLU_NURBS_ERROR27 = 0x187b5;
        public const uint GLU_NURBS_ERROR28 = 0x187b6;
        public const uint GLU_NURBS_ERROR29 = 0x187b7;
        public const uint GLU_NURBS_ERROR3 = 0x1879d;
        public const uint GLU_NURBS_ERROR30 = 0x187b8;
        public const uint GLU_NURBS_ERROR31 = 0x187b9;
        public const uint GLU_NURBS_ERROR32 = 0x187ba;
        public const uint GLU_NURBS_ERROR33 = 0x187bb;
        public const uint GLU_NURBS_ERROR34 = 0x187bc;
        public const uint GLU_NURBS_ERROR35 = 0x187bd;
        public const uint GLU_NURBS_ERROR36 = 0x187be;
        public const uint GLU_NURBS_ERROR37 = 0x187bf;
        public const uint GLU_NURBS_ERROR4 = 0x1879e;
        public const uint GLU_NURBS_ERROR5 = 0x1879f;
        public const uint GLU_NURBS_ERROR6 = 0x187a0;
        public const uint GLU_NURBS_ERROR7 = 0x187a1;
        public const uint GLU_NURBS_ERROR8 = 0x187a2;
        public const uint GLU_NURBS_ERROR9 = 0x187a3;
        public const uint GLU_OUT_OF_MEMORY = 0x18a26;
        public const uint GLU_OUTLINE_PATCH = 0x18791;
        public const uint GLU_OUTLINE_POLYGON = 0x18790;
        public const uint GLU_OUTSIDE = 0x186b4;
        public const uint GLU_PARAMETRIC_ERROR = 0x18778;
        public const uint GLU_PARAMETRIC_TOLERANCE = 0x1876a;
        public const uint GLU_PATH_LENGTH = 0x18777;
        public const uint GLU_POINT = 0x186aa;
        public const uint GLU_SAMPLING_METHOD = 0x1876d;
        public const uint GLU_SAMPLING_TOLERANCE = 0x1876b;
        public const uint GLU_SILHOUETTE = 0x186ad;
        public const uint GLU_SMOOTH = 0x186a0;
        public const uint GLU_TESS_BEGIN = 0x18704;
        public const uint GLU_TESS_BEGIN_DATA = 0x1870a;
        public const uint GLU_TESS_BOUNDARY_ONLY = 0x1872d;
        public const uint GLU_TESS_COMBINE = 0x18709;
        public const uint GLU_TESS_COMBINE_DATA = 0x1870f;
        public const uint GLU_TESS_COORD_TOO_LARGE = 0x1873b;
        public const uint GLU_TESS_EDGE_FLAG = 0x18708;
        public const uint GLU_TESS_EDGE_FLAG_DATA = 0x1870e;
        public const uint GLU_TESS_END = 0x18706;
        public const uint GLU_TESS_END_DATA = 0x1870c;
        public const uint GLU_TESS_ERROR = 0x18707;
        public const uint GLU_TESS_ERROR_DATA = 0x1870d;
        public const uint GLU_TESS_ERROR1 = 0x18737;
        public const uint GLU_TESS_ERROR2 = 0x18738;
        public const uint GLU_TESS_ERROR3 = 0x18739;
        public const uint GLU_TESS_ERROR4 = 0x1873a;
        public const uint GLU_TESS_ERROR5 = 0x1873b;
        public const uint GLU_TESS_ERROR6 = 0x1873c;
        public const uint GLU_TESS_ERROR7 = 0x1873d;
        public const uint GLU_TESS_ERROR8 = 0x1873e;
        public const double GLU_TESS_MAX_COORD = 1E+150;
        public const uint GLU_TESS_MISSING_BEGIN_CONTOUR = 0x18738;
        public const uint GLU_TESS_MISSING_BEGIN_POLYGON = 0x18737;
        public const uint GLU_TESS_MISSING_END_CONTOUR = 0x1873a;
        public const uint GLU_TESS_MISSING_END_POLYGON = 0x18739;
        public const uint GLU_TESS_NEED_COMBINE_CALLBACK = 0x1873c;
        public const uint GLU_TESS_TOLERANCE = 0x1872e;
        public const uint GLU_TESS_VERTEX = 0x18705;
        public const uint GLU_TESS_VERTEX_DATA = 0x1870b;
        public const uint GLU_TESS_WINDING_ABS_GEQ_TWO = 0x18726;
        public const uint GLU_TESS_WINDING_NEGATIVE = 0x18725;
        public const uint GLU_TESS_WINDING_NONZERO = 0x18723;
        public const uint GLU_TESS_WINDING_ODD = 0x18722;
        public const uint GLU_TESS_WINDING_POSITIVE = 0x18724;
        public const uint GLU_TESS_WINDING_RULE = 0x1872c;
        public const uint GLU_TRUE = 1;
        public const uint GLU_U_STEP = 0x1876e;
        public const uint GLU_V_STEP = 0x1876f;
        public const uint GLU_VERSION = 0x189c0;
        public const uint GLU_VERSION_1_1 = 1;
        public const uint GLU_VERSION_1_2 = 1;
        private Graphics graphics_0;
        private IntPtr intptr_0;
        private IntPtr intptr_1;
        private IntPtr intptr_2;
        public const string LIBRARY_OPENGL = "opengl32.dll";

        public OpenGL(Graphics g)
        {
            this.FOG_SPECULAR_TEXTURE_WIN = 0x80ec;
            this.intptr_0 = IntPtr.Zero;
            this.intptr_1 = IntPtr.Zero;
            this.intptr_2 = IntPtr.Zero;
            this.graphics_0 = null;
            this.graphics_0 = g;
            this.intptr_1 = g.GetHdc();
            PIXELFORMATDESCRIPTOR ppfd = new PIXELFORMATDESCRIPTOR();
            ppfd.Init();
            ppfd.nVersion = 1;
            ppfd.dwFlags = 60;
            ppfd.iPixelType = 0;
            ppfd.cColorBits = 0x18;
            ppfd.cDepthBits = 0x20;
            ppfd.cAlphaBits = 8;
            ppfd.iLayerType = 0;
            int iPixelFormat = DSkin.NativeMethods.ChoosePixelFormat(this.intptr_1, ppfd);
            DSkin.NativeMethods.SetPixelFormat(this.intptr_1, iPixelFormat, ppfd);
            this.intptr_0 = wglCreateContext(this.intptr_1);
            wglMakeCurrent(this.intptr_1, this.intptr_0);
        }

        public OpenGL(IntPtr handle)
        {
            this.FOG_SPECULAR_TEXTURE_WIN = 0x80ec;
            this.intptr_0 = IntPtr.Zero;
            this.intptr_1 = IntPtr.Zero;
            this.intptr_2 = IntPtr.Zero;
            this.graphics_0 = null;
            this.intptr_2 = handle;
            this.intptr_1 = DSkin.NativeMethods.GetDC(this.intptr_2);
            PIXELFORMATDESCRIPTOR ppfd = new PIXELFORMATDESCRIPTOR();
            ppfd.Init();
            ppfd.nVersion = 1;
            ppfd.dwFlags = 0x25;
            ppfd.iPixelType = 0;
            ppfd.cColorBits = 0x18;
            ppfd.cDepthBits = 0x10;
            ppfd.cStencilBits = 8;
            ppfd.iLayerType = 0;
            int iPixelFormat = DSkin.NativeMethods.ChoosePixelFormat(this.intptr_1, ppfd);
            DSkin.NativeMethods.SetPixelFormat(this.intptr_1, iPixelFormat, ppfd);
            this.intptr_0 = wglCreateContext(this.intptr_1);
            wglMakeCurrent(this.intptr_1, this.intptr_0);
        }

        public void Accum(AccumOperation op, float value)
        {
            this.vmethod_0();
            glAccum((uint) op, value);
            this.vmethod_1();
        }

        public void Accum(uint op, float value)
        {
            this.vmethod_0();
            glAccum(op, value);
            this.vmethod_1();
        }

        public void AlphaFunc(AlphaTestFunction function, float reference)
        {
            this.vmethod_0();
            glAlphaFunc((uint) function, reference);
            this.vmethod_1();
        }

        public void AlphaFunc(uint func, float reference)
        {
            this.vmethod_0();
            glAlphaFunc(func, reference);
            this.vmethod_1();
        }

        public byte AreTexturesResident(int n, uint[] textures, byte[] residences)
        {
            this.vmethod_0();
            byte num = glAreTexturesResident(n, textures, residences);
            this.vmethod_1();
            return num;
        }

        public void ArrayElement(int i)
        {
            this.vmethod_0();
            glArrayElement(i);
            this.vmethod_1();
        }

        public void Begin(BeginMode mode)
        {
            this.vmethod_0();
            glBegin((uint) mode);
        }

        public void Begin(uint mode)
        {
            this.vmethod_0();
            glBegin(mode);
        }

        public void BeginCurve(IntPtr nurbsObject)
        {
            this.vmethod_0();
            gluBeginCurve(nurbsObject);
            this.vmethod_1();
        }

        public void BeginSurface(IntPtr nurbsObject)
        {
            this.vmethod_0();
            gluBeginSurface(nurbsObject);
            this.vmethod_1();
        }

        public void BeginTrim(IntPtr nobj)
        {
            this.vmethod_0();
            gluBeginTrim(nobj);
            this.vmethod_1();
        }

        public void BindTexture(uint target, uint texture)
        {
            this.vmethod_0();
            glBindTexture(target, texture);
            this.vmethod_1();
        }

        public void Bitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap)
        {
            this.vmethod_0();
            glBitmap(width, height, xorig, yorig, xmove, ymove, bitmap);
            this.vmethod_1();
        }

        public void BlendFunc(BlendingSourceFactor sourceFactor, BlendingDestinationFactor destinationFactor)
        {
            this.vmethod_0();
            glBlendFunc((uint) sourceFactor, (uint) destinationFactor);
            this.vmethod_1();
        }

        public void BlendFunc(uint sfactor, uint dfactor)
        {
            this.vmethod_0();
            glBlendFunc(sfactor, dfactor);
            this.vmethod_1();
        }

        public void Build1DMipmaps(uint target, uint components, int width, uint format, uint type, IntPtr data)
        {
            this.vmethod_0();
            gluBuild1DMipmaps(target, components, width, format, type, data);
            this.vmethod_1();
        }

        public void Build2DMipmaps(uint target, uint components, int width, int height, uint format, uint type, IntPtr data)
        {
            this.vmethod_0();
            gluBuild2DMipmaps(target, components, width, height, format, type, data);
            this.vmethod_1();
        }

        public void CallList(uint list)
        {
            this.vmethod_0();
            glCallList(list);
            this.vmethod_1();
        }

        public void CallLists(int n, byte[] lists)
        {
            this.vmethod_0();
            glCallLists_2(n, 0x1401, lists);
            this.vmethod_1();
        }

        public void CallLists(int n, uint[] lists)
        {
            this.vmethod_0();
            glCallLists_1(n, 0x1405, lists);
            this.vmethod_1();
        }

        public void CallLists(int n, DataType type, IntPtr lists)
        {
            this.vmethod_0();
            glCallLists(n, (uint) type, lists);
            this.vmethod_1();
        }

        public void CallLists(int n, uint type, IntPtr lists)
        {
            this.vmethod_0();
            glCallLists(n, type, lists);
            this.vmethod_1();
        }

        public void Clear(uint mask)
        {
            this.vmethod_0();
            glClear(mask);
            this.vmethod_1();
        }

        public void ClearAccum(float red, float green, float blue, float alpha)
        {
            this.vmethod_0();
            glClearAccum(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void ClearColor(float red, float green, float blue, float alpha)
        {
            this.vmethod_0();
            glClearColor(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void ClearDepth(double depth)
        {
            this.vmethod_0();
            glClearDepth(depth);
            this.vmethod_1();
        }

        public void ClearIndex(float c)
        {
            this.vmethod_0();
            glClearIndex(c);
            this.vmethod_1();
        }

        public void ClearStencil(int s)
        {
            this.vmethod_0();
            glClearStencil(s);
            this.vmethod_1();
        }

        public void ClipPlane(ClipPlaneName plane, double[] equation)
        {
            this.vmethod_0();
            glClipPlane((uint) plane, equation);
            this.vmethod_1();
        }

        public void ClipPlane(uint plane, double[] equation)
        {
            this.vmethod_0();
            glClipPlane(plane, equation);
            this.vmethod_1();
        }

        public void Color(byte[] v)
        {
            this.vmethod_0();
            if (v.Length == 3)
            {
                glColor3bv(v);
            }
            else if (v.Length == 4)
            {
                glColor4bv(v);
            }
            this.vmethod_1();
        }

        public void Color(double[] v)
        {
            this.vmethod_0();
            if (v.Length == 3)
            {
                glColor3dv(v);
            }
            else if (v.Length == 4)
            {
                glColor4dv(v);
            }
            this.vmethod_1();
        }

        public void Color(short[] v)
        {
            this.vmethod_0();
            if (v.Length == 3)
            {
                glColor3sv(v);
            }
            else if (v.Length == 4)
            {
                glColor4sv(v);
            }
            this.vmethod_1();
        }

        public void Color(int[] v)
        {
            this.vmethod_0();
            if (v.Length == 3)
            {
                glColor3iv(v);
            }
            else if (v.Length == 4)
            {
                glColor4iv(v);
            }
            this.vmethod_1();
        }

        public void Color(float[] v)
        {
            this.vmethod_0();
            if (v.Length == 3)
            {
                glColor3fv(v);
            }
            else if (v.Length == 4)
            {
                glColor4fv(v);
            }
            this.vmethod_1();
        }

        public void Color(ushort[] v)
        {
            this.vmethod_0();
            if (v.Length == 3)
            {
                glColor3usv(v);
            }
            else if (v.Length == 4)
            {
                glColor4usv(v);
            }
            this.vmethod_1();
        }

        public void Color(uint[] v)
        {
            this.vmethod_0();
            if (v.Length == 3)
            {
                glColor3uiv(v);
            }
            else if (v.Length == 4)
            {
                glColor4uiv(v);
            }
            this.vmethod_1();
        }

        public void Color(byte red, byte green, byte blue)
        {
            this.vmethod_0();
            glColor3ub(red, green, blue);
            this.vmethod_1();
        }

        public void Color(double red, double green, double blue)
        {
            this.vmethod_0();
            glColor3d(red, green, blue);
            this.vmethod_1();
        }

        public void Color(short red, short green, short blue)
        {
            this.vmethod_0();
            glColor3s(red, green, blue);
            this.vmethod_1();
        }

        public void Color(int red, int green, int blue)
        {
            this.vmethod_0();
            glColor3i(red, green, blue);
            this.vmethod_1();
        }

        public void Color(float red, float green, float blue)
        {
            this.vmethod_0();
            glColor3f(red, green, blue);
            this.vmethod_1();
        }

        public void Color(ushort red, ushort green, ushort blue)
        {
            this.vmethod_0();
            glColor3us(red, green, blue);
            this.vmethod_1();
        }

        public void Color(uint red, uint green, uint blue)
        {
            this.vmethod_0();
            glColor3ui(red, green, blue);
            this.vmethod_1();
        }

        public void Color(byte red, byte green, byte blue, byte alpha)
        {
            this.vmethod_0();
            glColor4ub(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void Color(double red, double green, double blue, double alpha)
        {
            this.vmethod_0();
            glColor4d(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void Color(short red, short green, short blue, short alpha)
        {
            this.vmethod_0();
            glColor4s(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void Color(int red, int green, int blue, int alpha)
        {
            this.vmethod_0();
            glColor4i(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void Color(float red, float green, float blue, float alpha)
        {
            this.vmethod_0();
            glColor4f(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void Color(ushort red, ushort green, ushort blue, ushort alpha)
        {
            this.vmethod_0();
            glColor4us(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void Color(uint red, uint green, uint blue, uint alpha)
        {
            this.vmethod_0();
            glColor4ui(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void ColorMask(byte red, byte green, byte blue, byte alpha)
        {
            this.vmethod_0();
            glColorMask(red, green, blue, alpha);
            this.vmethod_1();
        }

        public void ColorMaterial(uint face, uint mode)
        {
            this.vmethod_0();
            glColorMaterial(face, mode);
            this.vmethod_1();
        }

        public void ColorPointer(int size, uint type, int stride, IntPtr pointer)
        {
            this.vmethod_0();
            glColorPointer(size, type, stride, pointer);
            this.vmethod_1();
        }

        public void CopyPixels(int x, int y, int width, int height, uint type)
        {
            this.vmethod_0();
            glCopyPixels(x, y, width, height, type);
            this.vmethod_1();
        }

        public void CopyTexImage1D(uint target, int level, uint internalFormat, int x, int y, int width, int border)
        {
            this.vmethod_0();
            glCopyTexImage1D(target, level, internalFormat, x, y, width, border);
            this.vmethod_1();
        }

        public void CopyTexImage2D(uint target, int level, uint internalFormat, int x, int y, int width, int height, int border)
        {
            this.vmethod_0();
            glCopyTexImage2D(target, level, internalFormat, x, y, width, height, border);
            this.vmethod_1();
        }

        public void CopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width)
        {
            this.vmethod_0();
            glCopyTexSubImage1D(target, level, xoffset, x, y, width);
            this.vmethod_1();
        }

        public void CopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
        {
            this.vmethod_0();
            glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
            this.vmethod_1();
        }

        public void CullFace(uint mode)
        {
            this.vmethod_0();
            glCullFace(mode);
            this.vmethod_1();
        }

        public void Cylinder(IntPtr qobj, double baseRadius, double topRadius, double height, int slices, int stacks)
        {
            this.vmethod_0();
            gluCylinder(qobj, baseRadius, topRadius, height, slices, stacks);
            this.vmethod_1();
        }

        public void DeleteLists(uint list, int range)
        {
            this.vmethod_0();
            glDeleteLists(list, range);
            this.vmethod_1();
        }

        public void DeleteNurbsRenderer(IntPtr nurbsObject)
        {
            this.vmethod_0();
            gluDeleteNurbsRenderer(nurbsObject);
            this.vmethod_1();
        }

        public void DeleteQuadric(IntPtr quadric)
        {
            this.vmethod_0();
            gluDeleteQuadric(quadric);
            this.vmethod_1();
        }

        public void DeleteTess(IntPtr tess)
        {
            this.vmethod_0();
            gluDeleteTess(tess);
            this.vmethod_1();
        }

        public void DeleteTextures(int n, uint[] textures)
        {
            this.vmethod_0();
            glDeleteTextures(n, textures);
            this.vmethod_1();
        }

        public void DepthFunc(DepthFunction function)
        {
            this.vmethod_0();
            glDepthFunc((uint) function);
            this.vmethod_1();
        }

        public void DepthFunc(uint func)
        {
            this.vmethod_0();
            glDepthFunc(func);
            this.vmethod_1();
        }

        public void DepthMask(byte flag)
        {
            this.vmethod_0();
            glDepthMask(flag);
            this.vmethod_1();
        }

        public void DepthRange(double zNear, double zFar)
        {
            this.vmethod_0();
            glDepthRange(zNear, zFar);
            this.vmethod_1();
        }

        public void Disable(uint cap)
        {
            this.vmethod_0();
            glDisable(cap);
            this.vmethod_1();
        }

        public void DisableClientState(uint array)
        {
            this.vmethod_0();
            glDisableClientState(array);
            this.vmethod_1();
        }

        public void Disk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops)
        {
            this.vmethod_0();
            gluDisk(qobj, innerRadius, outerRadius, slices, loops);
            this.vmethod_1();
        }

        public void Dispose()
        {
            if (this.graphics_0 != null)
            {
                this.graphics_0.ReleaseHdc(this.intptr_1);
            }
            if (this.intptr_2 != IntPtr.Zero)
            {
                this.SwapBuffers();
                DSkin.NativeMethods.ReleaseDC(this.intptr_2, this.intptr_1);
                this.intptr_2 = IntPtr.Zero;
            }
            if (this.intptr_0 != IntPtr.Zero)
            {
                wglDeleteContext(this.intptr_0);
                this.intptr_0 = IntPtr.Zero;
            }
            this.intptr_1 = IntPtr.Zero;
        }

        public void DrawArrays(uint mode, int first, int count)
        {
            this.vmethod_0();
            glDrawArrays(mode, first, count);
            this.vmethod_1();
        }

        public void DrawBuffer(DrawBufferMode drawBufferMode)
        {
            this.vmethod_0();
            glDrawBuffer((uint) drawBufferMode);
            this.vmethod_1();
        }

        public void DrawBuffer(uint mode)
        {
            this.vmethod_0();
            glDrawBuffer(mode);
            this.vmethod_1();
        }

        public void DrawElements(uint mode, int count, uint[] indices)
        {
            this.vmethod_0();
            glDrawElements_1(mode, count, 0x1405, indices);
            this.vmethod_1();
        }

        public void DrawElements(uint mode, int count, uint type, IntPtr indices)
        {
            this.vmethod_0();
            glDrawElements(mode, count, type, indices);
            this.vmethod_1();
        }

        public void DrawPixels(int width, int height, uint format, byte[] pixels)
        {
            this.vmethod_0();
            glDrawPixels_3(width, height, format, 0x1401, pixels);
            this.vmethod_1();
        }

        public void DrawPixels(int width, int height, uint format, float[] pixels)
        {
            this.vmethod_0();
            glDrawPixels(width, height, format, 0x1406, pixels);
            this.vmethod_1();
        }

        public void DrawPixels(int width, int height, uint format, ushort[] pixels)
        {
            this.vmethod_0();
            glDrawPixels_2(width, height, format, 0x1403, pixels);
            this.vmethod_1();
        }

        public void DrawPixels(int width, int height, uint format, uint[] pixels)
        {
            this.vmethod_0();
            glDrawPixels_1(width, height, format, 0x1405, pixels);
            this.vmethod_1();
        }

        public void DrawPixels(int width, int height, uint format, uint type, IntPtr pixels)
        {
            this.vmethod_0();
            glDrawPixels_4(width, height, format, type, pixels);
            this.vmethod_1();
        }

        public void EdgeFlag(byte flag)
        {
            this.vmethod_0();
            glEdgeFlag(flag);
            this.vmethod_1();
        }

        public void EdgeFlag(byte[] flag)
        {
            this.vmethod_0();
            glEdgeFlagv(flag);
            this.vmethod_1();
        }

        public void EdgeFlagPointer(int stride, int[] pointer)
        {
            this.vmethod_0();
            glEdgeFlagPointer(stride, pointer);
            this.vmethod_1();
        }

        public void Enable(uint cap)
        {
            this.vmethod_0();
            glEnable(cap);
            this.vmethod_1();
        }

        public void EnableClientState(uint array)
        {
            this.vmethod_0();
            glEnableClientState(array);
            this.vmethod_1();
        }

        public void EnableIf(uint cap, bool test)
        {
            if (test)
            {
                this.Enable(cap);
            }
            else
            {
                this.Disable(cap);
            }
        }

        public void End()
        {
            glEnd();
            this.vmethod_1();
        }

        public void EndCurve(IntPtr nurbsObject)
        {
            this.vmethod_0();
            gluEndCurve(nurbsObject);
            this.vmethod_1();
        }

        public void EndList()
        {
            this.vmethod_0();
            glEndList();
            this.vmethod_1();
        }

        public void EndSurface(IntPtr nurbsObject)
        {
            this.vmethod_0();
            gluEndSurface(nurbsObject);
            this.vmethod_1();
        }

        public void EndTrim(IntPtr nobj)
        {
            this.vmethod_0();
            gluEndTrim(nobj);
            this.vmethod_1();
        }

        public string ErrorString(uint errCode)
        {
            this.vmethod_0();
            string str = new string(gluErrorString(errCode));
            this.vmethod_1();
            return str;
        }

        public void EvalCoord1(double u)
        {
            this.vmethod_0();
            glEvalCoord1d(u);
            this.vmethod_1();
        }

        public void EvalCoord1(double[] u)
        {
            this.vmethod_0();
            glEvalCoord1dv(u);
            this.vmethod_1();
        }

        public void EvalCoord1(float u)
        {
            this.vmethod_0();
            glEvalCoord1f(u);
            this.vmethod_1();
        }

        public void EvalCoord1(float[] u)
        {
            this.vmethod_0();
            glEvalCoord1fv(u);
            this.vmethod_1();
        }

        public void EvalCoord2(double[] u)
        {
            this.vmethod_0();
            glEvalCoord2dv(u);
            this.vmethod_1();
        }

        public void EvalCoord2(float[] u)
        {
            this.vmethod_0();
            glEvalCoord2fv(u);
            this.vmethod_1();
        }

        public void EvalCoord2(double u, double v)
        {
            this.vmethod_0();
            glEvalCoord2d(u, v);
            this.vmethod_1();
        }

        public void EvalCoord2(float u, float v)
        {
            this.vmethod_0();
            glEvalCoord2f(u, v);
            this.vmethod_1();
        }

        public void EvalMesh1(uint mode, int i1, int i2)
        {
            this.vmethod_0();
            glEvalMesh1(mode, i1, i2);
            this.vmethod_1();
        }

        public void EvalMesh2(uint mode, int i1, int i2, int j1, int j2)
        {
            this.vmethod_0();
            glEvalMesh2(mode, i1, i2, j1, j2);
            this.vmethod_1();
        }

        public void EvalPoint1(int i)
        {
            this.vmethod_0();
            glEvalPoint1(i);
            this.vmethod_1();
        }

        public void EvalPoint2(int i, int j)
        {
            this.vmethod_0();
            glEvalPoint2(i, j);
            this.vmethod_1();
        }

        public void FeedbackBuffer(int size, uint type, float[] buffer)
        {
            this.vmethod_0();
            glFeedbackBuffer(size, type, buffer);
            this.vmethod_1();
        }

        public void Finish()
        {
            this.vmethod_0();
            glFinish();
            this.vmethod_1();
        }

        public void Flush()
        {
            this.vmethod_0();
            glFlush();
            this.vmethod_1();
        }

        public void Fog(uint pname, float[] parameters)
        {
            this.vmethod_0();
            glFogfv(pname, parameters);
            this.vmethod_1();
        }

        public void Fog(uint pname, int param)
        {
            this.vmethod_0();
            glFogi(pname, param);
            this.vmethod_1();
        }

        public void Fog(uint pname, float param)
        {
            this.vmethod_0();
            glFogf(pname, param);
            this.vmethod_1();
        }

        public void Fog(uint pname, int[] parameters)
        {
            this.vmethod_0();
            glFogiv(pname, parameters);
            this.vmethod_1();
        }

        public void FrontFace(uint mode)
        {
            this.vmethod_0();
            glFrontFace(mode);
            this.vmethod_1();
        }

        public void Frustum(double left, double right, double bottom, double top, double zNear, double zFar)
        {
            this.vmethod_0();
            glFrustum(left, right, bottom, top, zNear, zFar);
            this.vmethod_1();
        }

        public virtual void GDICoordinatetoOpenGLCoordinate(ref int x, ref int y)
        {
            int[] numArray = new int[4];
            glGetIntegerv(0xba2, numArray);
            y = numArray[3] - y;
        }

        public uint GenLists(int range)
        {
            this.vmethod_0();
            uint num = glGenLists(range);
            this.vmethod_1();
            return num;
        }

        public void GenTextures(int n, uint[] textures)
        {
            this.vmethod_0();
            glGenTextures(n, textures);
            this.vmethod_1();
        }

        public void GetBooleanv(GetTarget pname, byte[] parameters)
        {
            this.vmethod_0();
            glGetBooleanv((uint) pname, parameters);
            this.vmethod_1();
        }

        public void GetBooleanv(uint pname, byte[] parameters)
        {
            this.vmethod_0();
            glGetBooleanv(pname, parameters);
            this.vmethod_1();
        }

        public void GetClipPlane(uint plane, double[] equation)
        {
            this.vmethod_0();
            glGetClipPlane(plane, equation);
            this.vmethod_1();
        }

        public void GetDouble(GetTarget pname, double[] parameters)
        {
            this.vmethod_0();
            glGetDoublev((uint) pname, parameters);
            this.vmethod_1();
        }

        public void GetDouble(uint pname, double[] parameters)
        {
            this.vmethod_0();
            glGetDoublev(pname, parameters);
            this.vmethod_1();
        }

        public uint GetError()
        {
            return glGetError();
        }

        public ErrorCode GetErrorCode()
        {
            return (ErrorCode) glGetError();
        }

        public string GetErrorDescription(uint errorCode)
        {
            switch (errorCode)
            {
                case 0x500:
                    return "A GLenum argument was out of range.";

                case 0x501:
                    return "A numeric argument was out of range.";

                case 0x502:
                    return "Invalid operation.";

                case 0x503:
                    return "Command would cause a stack overflow.";

                case 0x504:
                    return "Command would cause a stack underflow.";

                case 0x505:
                    return "Not enough memory left to execute command.";

                case 0:
                    return "No Error";
            }
            return "Unknown Error";
        }

        public void GetFloat(GetTarget pname, float[] parameters)
        {
            this.vmethod_0();
            glGetFloatv((uint) pname, parameters);
            this.vmethod_1();
        }

        public void GetFloat(uint pname, float[] parameters)
        {
            this.vmethod_0();
            glGetFloatv(pname, parameters);
            this.vmethod_1();
        }

        public void GetInteger(GetTarget pname, int[] parameters)
        {
            this.vmethod_0();
            glGetIntegerv((uint) pname, parameters);
            this.vmethod_1();
        }

        public void GetInteger(uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetIntegerv(pname, parameters);
            this.vmethod_1();
        }

        public void GetLight(uint light, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetLightiv(light, pname, parameters);
            this.vmethod_1();
        }

        public void GetLight(uint light, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glGetLightfv(light, pname, parameters);
            this.vmethod_1();
        }

        public void GetMap(GetMapTarget target, uint query, double[] v)
        {
            this.vmethod_0();
            glGetMapdv((uint) target, query, v);
            this.vmethod_1();
        }

        public void GetMap(GetMapTarget target, uint query, int[] v)
        {
            this.vmethod_0();
            glGetMapiv((uint) target, query, v);
            this.vmethod_1();
        }

        public void GetMap(GetMapTarget target, uint query, float[] v)
        {
            this.vmethod_0();
            glGetMapfv((uint) target, query, v);
            this.vmethod_1();
        }

        public void GetMap(uint target, uint query, double[] v)
        {
            this.vmethod_0();
            glGetMapdv(target, query, v);
            this.vmethod_1();
        }

        public void GetMap(uint target, uint query, int[] v)
        {
            this.vmethod_0();
            glGetMapiv(target, query, v);
            this.vmethod_1();
        }

        public void GetMap(uint target, uint query, float[] v)
        {
            this.vmethod_0();
            glGetMapfv(target, query, v);
            this.vmethod_1();
        }

        public void GetMaterial(uint face, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetMaterialiv(face, pname, parameters);
            this.vmethod_1();
        }

        public void GetMaterial(uint face, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glGetMaterialfv(face, pname, parameters);
            this.vmethod_1();
        }

        public void GetNurbsProperty(IntPtr nobj, int property, float value)
        {
            this.vmethod_0();
            gluGetNurbsProperty(nobj, property, value);
            this.vmethod_1();
        }

        public void GetPixelMap(uint map, float[] values)
        {
            this.vmethod_0();
            glGetPixelMapfv(map, values);
            this.vmethod_1();
        }

        public void GetPixelMap(uint map, ushort[] values)
        {
            this.vmethod_0();
            glGetPixelMapusv(map, values);
            this.vmethod_1();
        }

        public void GetPixelMap(uint map, uint[] values)
        {
            this.vmethod_0();
            glGetPixelMapuiv(map, values);
            this.vmethod_1();
        }

        public void GetPointerv(uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetPointerv(pname, parameters);
            this.vmethod_1();
        }

        public void GetPolygonStipple(byte[] mask)
        {
            this.vmethod_0();
            glGetPolygonStipple(mask);
            this.vmethod_1();
        }

        public string GetString(int name)
        {
            this.vmethod_0();
            string str = new string(gluGetString(name));
            this.vmethod_1();
            return str;
        }

        public string GetString(uint name)
        {
            this.vmethod_0();
            string str = new string(glGetString(name));
            this.vmethod_1();
            return str;
        }

        public void GetTessProperty(IntPtr tess, int which, double value)
        {
            this.vmethod_0();
            gluGetTessProperty(tess, which, value);
            this.vmethod_1();
        }

        public void GetTexEnv(uint target, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetTexEnviv(target, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexEnv(uint target, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glGetTexEnvfv(target, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexGen(uint coord, uint pname, double[] parameters)
        {
            this.vmethod_0();
            glGetTexGendv(coord, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexGen(uint coord, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetTexGeniv(coord, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexGen(uint coord, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glGetTexGenfv(coord, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexImage(uint target, int level, uint format, uint type, int[] pixels)
        {
            this.vmethod_0();
            glGetTexImage(target, level, format, type, pixels);
            this.vmethod_1();
        }

        public void GetTexLevelParameter(uint target, int level, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetTexLevelParameteriv(target, level, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexLevelParameter(uint target, int level, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glGetTexLevelParameterfv(target, level, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexParameter(uint target, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glGetTexParameteriv(target, pname, parameters);
            this.vmethod_1();
        }

        public void GetTexParameter(uint target, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glGetTexParameterfv(target, pname, parameters);
            this.vmethod_1();
        }

        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glAccum(uint uint_0, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glAlphaFunc(uint uint_0, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern byte glAreTexturesResident(int int_0, uint[] uint_0, byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glArrayElement(int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glBegin(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glBindTexture(uint uint_0, uint uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glBitmap(int int_0, int int_1, float float_0, float float_1, float float_2, float float_3, byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glBlendFunc(uint uint_0, uint uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCallList(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCallLists(int int_0, uint uint_0, IntPtr intptr_3);
        [DllImport("opengl32.dll", EntryPoint="glCallLists", SetLastError=true)]
        private static extern void glCallLists_1(int int_0, uint uint_0, uint[] uint_1);
        [DllImport("opengl32.dll", EntryPoint="glCallLists", SetLastError=true)]
        private static extern void glCallLists_2(int int_0, uint uint_0, byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glClear(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glClearAccum(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glClearColor(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glClearDepth(double double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glClearIndex(float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glClearStencil(int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glClipPlane(uint uint_0, double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3b(byte byte_0, byte byte_1, byte byte_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3bv(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3d(double double_0, double double_1, double double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3f(float float_0, float float_1, float float_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3i(int int_0, int int_1, int int_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3s(short short_0, short short_1, short short_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3ub(byte byte_0, byte byte_1, byte byte_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3ubv(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3ui(uint uint_0, uint uint_1, uint uint_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3uiv(uint[] uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3us(ushort ushort_0, ushort ushort_1, ushort ushort_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor3usv(ushort[] ushort_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4b(byte byte_0, byte byte_1, byte byte_2, byte byte_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4bv(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4d(double double_0, double double_1, double double_2, double double_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4f(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4i(int int_0, int int_1, int int_2, int int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4s(short short_0, short short_1, short short_2, short short_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4ub(byte byte_0, byte byte_1, byte byte_2, byte byte_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4ubv(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4ui(uint uint_0, uint uint_1, uint uint_2, uint uint_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4uiv(uint[] uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4us(ushort ushort_0, ushort ushort_1, ushort ushort_2, ushort ushort_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColor4usv(ushort[] ushort_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColorMask(byte byte_0, byte byte_1, byte byte_2, byte byte_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColorMaterial(uint uint_0, uint uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glColorPointer(int int_0, uint uint_0, int int_1, IntPtr intptr_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCopyPixels(int int_0, int int_1, int int_2, int int_3, uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCopyTexImage1D(uint uint_0, int int_0, uint uint_1, int int_1, int int_2, int int_3, int int_4);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCopyTexImage2D(uint uint_0, int int_0, uint uint_1, int int_1, int int_2, int int_3, int int_4, int int_5);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCopyTexSubImage1D(uint uint_0, int int_0, int int_1, int int_2, int int_3, int int_4);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCopyTexSubImage2D(uint uint_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glCullFace(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDeleteLists(uint uint_0, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDeleteTextures(int int_0, uint[] uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDepthFunc(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDepthMask(byte byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDepthRange(double double_0, double double_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDisable(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDisableClientState(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDrawArrays(uint uint_0, int int_0, int int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDrawBuffer(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDrawElements(uint uint_0, int int_0, uint uint_1, IntPtr intptr_3);
        [DllImport("opengl32.dll", EntryPoint="glDrawElements", SetLastError=true)]
        private static extern void glDrawElements_1(uint uint_0, int int_0, uint uint_1, uint[] uint_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glDrawPixels(int int_0, int int_1, uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", EntryPoint="glDrawPixels", SetLastError=true)]
        private static extern void glDrawPixels_1(int int_0, int int_1, uint uint_0, uint uint_1, uint[] uint_2);
        [DllImport("opengl32.dll", EntryPoint="glDrawPixels", SetLastError=true)]
        private static extern void glDrawPixels_2(int int_0, int int_1, uint uint_0, uint uint_1, ushort[] ushort_0);
        [DllImport("opengl32.dll", EntryPoint="glDrawPixels", SetLastError=true)]
        private static extern void glDrawPixels_3(int int_0, int int_1, uint uint_0, uint uint_1, byte[] byte_0);
        [DllImport("opengl32.dll", EntryPoint="glDrawPixels", SetLastError=true)]
        private static extern void glDrawPixels_4(int int_0, int int_1, uint uint_0, uint uint_1, IntPtr intptr_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEdgeFlag(byte byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEdgeFlagPointer(int int_0, int[] int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEdgeFlagv(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEnable(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEnableClientState(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEnd();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEndList();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord1d(double double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord1dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord1f(float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord1fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord2d(double double_0, double double_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord2dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord2f(float float_0, float float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalCoord2fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalMesh1(uint uint_0, int int_0, int int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalMesh2(uint uint_0, int int_0, int int_1, int int_2, int int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalPoint1(int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glEvalPoint2(int int_0, int int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFeedbackBuffer(int int_0, uint uint_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFinish();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFlush();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFogf(uint uint_0, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFogfv(uint uint_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFogi(uint uint_0, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFogiv(uint uint_0, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFrontFace(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glFrustum(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern uint glGenLists(int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGenTextures(int int_0, uint[] uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetBooleanv(uint uint_0, byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetClipPlane(uint uint_0, double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetDoublev(uint uint_0, double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern uint glGetError();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetFloatv(uint uint_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetIntegerv(uint uint_0, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetLightfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetLightiv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetMapdv(uint uint_0, uint uint_1, double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetMapfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetMapiv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetMaterialfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetMaterialiv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetPixelMapfv(uint uint_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetPixelMapuiv(uint uint_0, uint[] uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetPixelMapusv(uint uint_0, ushort[] ushort_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetPointerv(uint uint_0, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetPolygonStipple(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern unsafe sbyte* glGetString(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexEnvfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexEnviv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexGendv(uint uint_0, uint uint_1, double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexGenfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexGeniv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexImage(uint uint_0, int int_0, uint uint_1, uint uint_2, int[] int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexLevelParameterfv(uint uint_0, int int_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexLevelParameteriv(uint uint_0, int int_0, uint uint_1, int[] int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexParameterfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glGetTexParameteriv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glHint(uint uint_0, uint uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexd(double double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexdv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexf(float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexfv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexi(int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexiv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexMask(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexPointer(uint uint_0, int int_0, int[] int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexs(short short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexsv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexub(byte byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glIndexubv(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glInitNames();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glInterleavedArrays(uint uint_0, int int_0, int[] int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern byte glIsEnabled(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern byte glIsList(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern byte glIsTexture(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLightf(uint uint_0, uint uint_1, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLightfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLighti(uint uint_0, uint uint_1, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLightiv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLightModelf(uint uint_0, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLightModelfv(uint uint_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLightModeli(uint uint_0, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLightModeliv(uint uint_0, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLineStipple(int int_0, ushort ushort_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLineWidth(float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glListBase(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLoadIdentity();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLoadMatrixd(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLoadMatrixf(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLoadName(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glLogicOp(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMap1d(uint uint_0, double double_0, double double_1, int int_0, int int_1, double[] double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMap1f(uint uint_0, float float_0, float float_1, int int_0, int int_1, float[] float_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMap2d(uint uint_0, double double_0, double double_1, int int_0, int int_1, double double_2, double double_3, int int_2, int int_3, double[] double_4);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMap2f(uint uint_0, float float_0, float float_1, int int_0, int int_1, float float_2, float float_3, int int_2, int int_3, float[] float_4);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMapGrid1d(int int_0, double double_0, double double_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMapGrid1f(int int_0, float float_0, float float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMapGrid2d(int int_0, double double_0, double double_1, int int_1, double double_2, double double_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMapGrid2f(int int_0, float float_0, float float_1, int int_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMaterialf(uint uint_0, uint uint_1, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMaterialfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMateriali(uint uint_0, uint uint_1, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMaterialiv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMatrixMode(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMultMatrixd(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glMultMatrixf(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNewList(uint uint_0, uint uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3b(byte byte_0, byte byte_1, byte byte_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3bv(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3d(double double_0, double double_1, double double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3f(float float_0, float float_1, float float_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3i(int int_0, int int_1, int int_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3s(short short_0, short short_1, short short_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormal3sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glNormalPointer(uint uint_0, int int_0, IntPtr intptr_3);
        [DllImport("opengl32.dll", EntryPoint="glNormalPointer", SetLastError=true)]
        private static extern void glNormalPointer_1(uint uint_0, int int_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glOrtho(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPassThrough(float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelMapfv(uint uint_0, int int_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelMapuiv(uint uint_0, int int_0, uint[] uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelMapusv(uint uint_0, int int_0, ushort[] ushort_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelStoref(uint uint_0, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelStorei(uint uint_0, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelTransferf(uint uint_0, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelTransferi(uint uint_0, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPixelZoom(float float_0, float float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPointSize(float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPolygonMode(uint uint_0, uint uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPolygonOffset(float float_0, float float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPolygonStipple(byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPopAttrib();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPopClientAttrib();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPopMatrix();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPopName();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPrioritizeTextures(int int_0, uint[] uint_0, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPushAttrib(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPushClientAttrib(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPushMatrix();
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glPushName(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2d(double double_0, double double_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2f(float float_0, float float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2i(int int_0, int int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2s(short short_0, short short_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos2sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3d(double double_0, double double_1, double double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3f(float float_0, float float_1, float float_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3i(int int_0, int int_1, int int_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3s(short short_0, short short_1, short short_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos3sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4d(double double_0, double double_1, double double_2, double double_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4f(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4i(int int_0, int int_1, int int_2, int int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4s(short short_0, short short_1, short short_2, short short_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRasterPos4sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glReadBuffer(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glReadPixels(int int_0, int int_1, int int_2, int int_3, uint uint_0, uint uint_1, byte[] byte_0);
        [DllImport("opengl32.dll", EntryPoint="glReadPixels", SetLastError=true)]
        private static extern void glReadPixels_1(int int_0, int int_1, int int_2, int int_3, uint uint_0, uint uint_1, IntPtr intptr_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRectd(double double_0, double double_1, double double_2, double double_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRectdv(double[] double_0, double[] double_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRectf(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRectfv(float[] float_0, float[] float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRecti(int int_0, int int_1, int int_2, int int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRectiv(int[] int_0, int[] int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRects(short short_0, short short_1, short short_2, short short_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRectsv(short[] short_0, short[] short_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern int glRenderMode(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRotated(double double_0, double double_1, double double_2, double double_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glRotatef(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glScaled(double double_0, double double_1, double double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glScalef(float float_0, float float_1, float float_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glScissor(int int_0, int int_1, int int_2, int int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glSelectBuffer(int int_0, uint[] uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glShadeModel(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glStencilFunc(uint uint_0, int int_0, uint uint_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glStencilMask(uint uint_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glStencilOp(uint uint_0, uint uint_1, uint uint_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1d(double double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1f(float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1i(int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1s(short short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord1sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2d(double double_0, double double_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2f(float float_0, float float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2i(int int_0, int int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2s(short short_0, short short_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord2sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3d(double double_0, double double_1, double double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3f(float float_0, float float_1, float float_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3i(int int_0, int int_1, int int_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3s(short short_0, short short_1, short short_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord3sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4d(double double_0, double double_1, double double_2, double double_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4f(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4i(int int_0, int int_1, int int_2, int int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4s(short short_0, short short_1, short short_2, short short_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoord4sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexCoordPointer(int int_0, uint uint_0, int int_1, IntPtr intptr_3);
        [DllImport("opengl32.dll", EntryPoint="glTexCoordPointer", SetLastError=true)]
        private static extern void glTexCoordPointer_1(int int_0, uint uint_0, int int_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexEnvf(uint uint_0, uint uint_1, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexEnvfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexEnvi(uint uint_0, uint uint_1, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexEnviv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexGend(uint uint_0, uint uint_1, double double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexGendv(uint uint_0, uint uint_1, double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexGenf(uint uint_0, uint uint_1, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexGenfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexGeni(uint uint_0, uint uint_1, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexGeniv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexImage1D(uint uint_0, int int_0, uint uint_1, int int_1, int int_2, uint uint_2, uint uint_3, byte[] byte_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexImage2D(uint uint_0, int int_0, uint uint_1, int int_1, int int_2, int int_3, uint uint_2, uint uint_3, byte[] byte_0);
        [DllImport("opengl32.dll", EntryPoint="glTexImage2D", SetLastError=true)]
        private static extern void glTexImage2D_1(uint uint_0, int int_0, uint uint_1, int int_1, int int_2, int int_3, uint uint_2, uint uint_3, IntPtr intptr_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexParameterf(uint uint_0, uint uint_1, float float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexParameterfv(uint uint_0, uint uint_1, float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexParameteri(uint uint_0, uint uint_1, int int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexParameteriv(uint uint_0, uint uint_1, int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexSubImage1D(uint uint_0, int int_0, int int_1, int int_2, uint uint_1, uint uint_2, int[] int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTexSubImage2D(uint uint_0, int int_0, int int_1, int int_2, int int_3, int int_4, uint uint_1, uint uint_2, int[] int_5);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTranslated(double double_0, double double_1, double double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glTranslatef(float float_0, float float_1, float float_2);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluBeginCurve(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluBeginSurface(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluBeginTrim(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluBuild1DMipmaps(uint uint_0, uint uint_1, int int_0, uint uint_2, uint uint_3, IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluBuild2DMipmaps(uint uint_0, uint uint_1, int int_0, int int_1, uint uint_2, uint uint_3, IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluCylinder(IntPtr intptr_3, double double_0, double double_1, double double_2, int int_0, int int_1);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluDeleteNurbsRenderer(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluDeleteQuadric(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluDeleteTess(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluDisk(IntPtr intptr_3, double double_0, double double_1, int int_0, int int_1);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluEndCurve(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluEndSurface(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluEndTrim(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern unsafe sbyte* gluErrorString(uint uint_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluGetNurbsProperty(IntPtr intptr_3, int int_0, float float_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern unsafe sbyte* gluGetString(int int_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluGetTessProperty(IntPtr intptr_3, int int_0, double double_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluLoadSamplingMatrices(IntPtr intptr_3, float[] float_0, float[] float_1, int[] int_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluLookAt(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern IntPtr gluNewNurbsRenderer();
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern IntPtr gluNewQuadric();
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern IntPtr gluNewTess();
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluNurbsCurve(IntPtr intptr_3, int int_0, float[] float_0, int int_1, float[] float_1, int int_2, uint uint_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluNurbsProperty(IntPtr intptr_3, int int_0, float float_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluNurbsSurface(IntPtr intptr_3, int int_0, float[] float_0, int int_1, float[] float_1, int int_2, int int_3, float[] float_2, int int_4, int int_5, uint uint_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluOrtho2D(double double_0, double double_1, double double_2, double double_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluPartialDisk(IntPtr intptr_3, double double_0, double double_1, int int_0, int int_1, double double_2, double double_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluPerspective(double double_0, double double_1, double double_2, double double_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluPickMatrix(double double_0, double double_1, double double_2, double double_3, int[] int_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluProject(double double_0, double double_1, double double_2, double[] double_3, double[] double_4, int[] int_0, double[] double_5, double[] double_6, double[] double_7);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluPwlCurve(IntPtr intptr_3, int int_0, float float_0, int int_1, uint uint_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluQuadricDrawStyle(IntPtr intptr_3, uint uint_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluQuadricNormals(IntPtr intptr_3, uint uint_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluQuadricOrientation(IntPtr intptr_3, int int_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluQuadricTexture(IntPtr intptr_3, int int_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluScaleImage(int int_0, int int_1, int int_2, int int_3, int[] int_4, int int_5, int int_6, int int_7, int[] int_8);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluSphere(IntPtr intptr_3, double double_0, int int_0, int int_1);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluTessBeginContour(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluTessBeginPolygon(IntPtr intptr_3, IntPtr intptr_4);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluTessEndContour(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluTessEndPolygon(IntPtr intptr_3);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluTessNormal(IntPtr intptr_3, double double_0, double double_1, double double_2);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluTessProperty(IntPtr intptr_3, int int_0, double double_0);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluTessVertex(IntPtr intptr_3, double[] double_0, double[] double_1);
        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void gluUnProject(double double_0, double double_1, double double_2, double[] double_3, double[] double_4, int[] int_0, ref double double_5, ref double double_6, ref double double_7);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2d(double double_0, double double_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2f(float float_0, float float_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2i(int int_0, int int_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2s(short short_0, short short_1);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex2sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3d(double double_0, double double_1, double double_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3f(float float_0, float float_1, float float_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3i(int int_0, int int_1, int int_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3s(short short_0, short short_1, short short_2);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex3sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4d(double double_0, double double_1, double double_2, double double_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4dv(double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4f(float float_0, float float_1, float float_2, float float_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4fv(float[] float_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4i(int int_0, int int_1, int int_2, int int_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4iv(int[] int_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4s(short short_0, short short_1, short short_2, short short_3);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertex4sv(short[] short_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glVertexPointer(int int_0, uint uint_0, int int_1, IntPtr intptr_3);
        [DllImport("opengl32.dll", EntryPoint="glVertexPointer", SetLastError=true)]
        private static extern void glVertexPointer_1(int int_0, uint uint_0, int int_1, short[] short_0);
        [DllImport("opengl32.dll", EntryPoint="glVertexPointer", SetLastError=true)]
        private static extern void glVertexPointer_2(int int_0, uint uint_0, int int_1, int[] int_2);
        [DllImport("opengl32.dll", EntryPoint="glVertexPointer", SetLastError=true)]
        private static extern void glVertexPointer_3(int int_0, uint uint_0, int int_1, float[] float_0);
        [DllImport("opengl32.dll", EntryPoint="glVertexPointer", SetLastError=true)]
        private static extern void glVertexPointer_4(int int_0, uint uint_0, int int_1, double[] double_0);
        [DllImport("opengl32.dll", SetLastError=true)]
        private static extern void glViewport(int int_0, int int_1, int int_2, int int_3);
        public void Hint(HintTarget target, HintMode mode)
        {
            this.vmethod_0();
            glHint((uint) target, (uint) mode);
            this.vmethod_1();
        }

        public void Hint(uint target, uint mode)
        {
            this.vmethod_0();
            glHint(target, mode);
            this.vmethod_1();
        }

        public void Index(double c)
        {
            this.vmethod_0();
            glIndexd(c);
            this.vmethod_1();
        }

        public void Index(short c)
        {
            this.vmethod_0();
            glIndexs(c);
            this.vmethod_1();
        }

        public void Index(int c)
        {
            this.vmethod_0();
            glIndexi(c);
            this.vmethod_1();
        }

        public void Index(float c)
        {
            this.vmethod_0();
            glIndexf(c);
            this.vmethod_1();
        }

        public void Index(byte[] c)
        {
            this.vmethod_0();
            glIndexubv(c);
            this.vmethod_1();
        }

        public void Index(double[] c)
        {
            this.vmethod_0();
            glIndexdv(c);
            this.vmethod_1();
        }

        public void Index(short[] c)
        {
            this.vmethod_0();
            glIndexsv(c);
            this.vmethod_1();
        }

        public void Index(int[] c)
        {
            this.vmethod_0();
            glIndexiv(c);
            this.vmethod_1();
        }

        public void Index(float[] c)
        {
            this.vmethod_0();
            glIndexfv(c);
            this.vmethod_1();
        }

        public void Index(byte c)
        {
            this.vmethod_0();
            glIndexub(c);
            this.vmethod_1();
        }

        public void IndexMask(uint mask)
        {
            this.vmethod_0();
            glIndexMask(mask);
            this.vmethod_1();
        }

        public void IndexPointer(uint type, int stride, int[] pointer)
        {
            this.vmethod_0();
            glIndexPointer(type, stride, pointer);
            this.vmethod_1();
        }

        public void InitNames()
        {
            this.vmethod_0();
            glInitNames();
            this.vmethod_1();
        }

        public void InterleavedArrays(uint format, int stride, int[] pointer)
        {
            this.vmethod_0();
            glInterleavedArrays(format, stride, pointer);
            this.vmethod_1();
        }

        [DllImport("Glu32.dll", SetLastError=true)]
        private static extern void IntPtrCallback(IntPtr intptr_3, int int_0, IntPtr intptr_4);
        public bool IsEnabled(uint cap)
        {
            this.vmethod_0();
            byte num = glIsEnabled(cap);
            this.vmethod_1();
            return (num != 0);
        }

        public byte IsList(uint list)
        {
            this.vmethod_0();
            byte num = glIsList(list);
            this.vmethod_1();
            return num;
        }

        public byte IsTexture(uint texture)
        {
            this.vmethod_0();
            byte num = glIsTexture(texture);
            this.vmethod_1();
            return num;
        }

        public void Light(LightName light, LightParameter pname, float[] parameters)
        {
            this.vmethod_0();
            glLightfv((uint) light, (uint) pname, parameters);
            this.vmethod_1();
        }

        public void Light(LightName light, LightParameter pname, int param)
        {
            this.vmethod_0();
            glLighti((uint) light, (uint) pname, param);
            this.vmethod_1();
        }

        public void Light(LightName light, LightParameter pname, float param)
        {
            this.vmethod_0();
            glLightf((uint) light, (uint) pname, param);
            this.vmethod_1();
        }

        public void Light(LightName light, LightParameter pname, int[] parameters)
        {
            this.vmethod_0();
            glLightiv((uint) light, (uint) pname, parameters);
            this.vmethod_1();
        }

        public void Light(uint light, uint pname, float param)
        {
            this.vmethod_0();
            glLightf(light, pname, param);
            this.vmethod_1();
        }

        public void Light(uint light, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glLightiv(light, pname, parameters);
            this.vmethod_1();
        }

        public void Light(uint light, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glLightfv(light, pname, parameters);
            this.vmethod_1();
        }

        public void Light(uint light, uint pname, int param)
        {
            this.vmethod_0();
            glLighti(light, pname, param);
            this.vmethod_1();
        }

        public void LightModel(LightModelParameter pname, int param)
        {
            this.vmethod_0();
            glLightModeli((uint) pname, param);
            this.vmethod_1();
        }

        public void LightModel(LightModelParameter pname, float param)
        {
            this.vmethod_0();
            glLightModelf((uint) pname, param);
            this.vmethod_1();
        }

        public void LightModel(LightModelParameter pname, int[] parameters)
        {
            this.vmethod_0();
            glLightModeliv((uint) pname, parameters);
            this.vmethod_1();
        }

        public void LightModel(LightModelParameter pname, float[] parameters)
        {
            this.vmethod_0();
            glLightModelfv((uint) pname, parameters);
            this.vmethod_1();
        }

        public void LightModel(uint pname, float[] parameters)
        {
            this.vmethod_0();
            glLightModelfv(pname, parameters);
            this.vmethod_1();
        }

        public void LightModel(uint pname, int param)
        {
            this.vmethod_0();
            glLightModeli(pname, param);
            this.vmethod_1();
        }

        public void LightModel(uint pname, float param)
        {
            this.vmethod_0();
            glLightModelf(pname, param);
            this.vmethod_1();
        }

        public void LightModel(uint pname, int[] parameters)
        {
            this.vmethod_0();
            glLightModeliv(pname, parameters);
            this.vmethod_1();
        }

        public void LineStipple(int factor, ushort pattern)
        {
            this.vmethod_0();
            glLineStipple(factor, pattern);
            this.vmethod_1();
        }

        public void LineWidth(float width)
        {
            this.vmethod_0();
            glLineWidth(width);
            this.vmethod_1();
        }

        public void ListBase(uint listbase)
        {
            this.vmethod_0();
            glListBase(listbase);
            this.vmethod_1();
        }

        public void LoadIdentity()
        {
            this.vmethod_0();
            glLoadIdentity();
            this.vmethod_1();
        }

        public void LoadMatrix(double[] m)
        {
            this.vmethod_0();
            glLoadMatrixd(m);
            this.vmethod_0();
        }

        public void LoadMatrixf(float[] m)
        {
            this.vmethod_0();
            glLoadMatrixf(m);
            this.vmethod_0();
        }

        public void LoadName(uint name)
        {
            this.vmethod_0();
            glLoadName(name);
            this.vmethod_1();
        }

        public void LoadSamplingMatrices(IntPtr nobj, float[] modelMatrix, float[] projMatrix, int[] viewport)
        {
            this.vmethod_0();
            gluLoadSamplingMatrices(nobj, modelMatrix, projMatrix, viewport);
            this.vmethod_1();
        }

        public void LogicOp(DSkin.OpenGL.LogicOp logicOp)
        {
            this.vmethod_0();
            glLogicOp((uint) logicOp);
            this.vmethod_1();
        }

        public void LogicOp(uint opcode)
        {
            this.vmethod_0();
            glLogicOp(opcode);
            this.vmethod_1();
        }

        public void LookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz)
        {
            this.vmethod_0();
            gluLookAt(eyex, eyey, eyez, centerx, centery, centerz, upx, upy, upz);
            this.vmethod_1();
        }

        public void Map1(uint target, double u1, double u2, int stride, int order, double[] points)
        {
            this.vmethod_0();
            glMap1d(target, u1, u2, stride, order, points);
            this.vmethod_1();
        }

        public void Map1(uint target, float u1, float u2, int stride, int order, float[] points)
        {
            this.vmethod_0();
            glMap1f(target, u1, u2, stride, order, points);
            this.vmethod_1();
        }

        public void Map2(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double[] points)
        {
            this.vmethod_0();
            glMap2d(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
            this.vmethod_1();
        }

        public void Map2(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float[] points)
        {
            this.vmethod_0();
            glMap2f(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
            this.vmethod_1();
        }

        public void MapGrid1(int un, double u1, double u2)
        {
            this.vmethod_0();
            glMapGrid1d(un, u1, u2);
            this.vmethod_1();
        }

        public void MapGrid1(int un, float u1, float u2)
        {
            this.vmethod_0();
            glMapGrid1d(un, (double) u1, (double) u2);
            this.vmethod_1();
        }

        public void MapGrid2(int un, double u1, double u2, int vn, double v1, double v2)
        {
            this.vmethod_0();
            glMapGrid2d(un, u1, u2, vn, v1, v2);
            this.vmethod_1();
        }

        public void MapGrid2(int un, float u1, float u2, int vn, float v1, float v2)
        {
            this.vmethod_0();
            glMapGrid2f(un, u1, u2, vn, v1, v2);
            this.vmethod_1();
        }

        public void Material(uint face, uint pname, int param)
        {
            this.vmethod_0();
            glMateriali(face, pname, param);
            this.vmethod_1();
        }

        public void Material(uint face, uint pname, float param)
        {
            this.vmethod_0();
            glMaterialf(face, pname, param);
            this.vmethod_1();
        }

        public void Material(uint face, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glMaterialiv(face, pname, parameters);
            this.vmethod_1();
        }

        public void Material(uint face, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glMaterialfv(face, pname, parameters);
            this.vmethod_1();
        }

        public void MatrixMode(DSkin.OpenGL.MatrixMode mode)
        {
            this.vmethod_0();
            glMatrixMode((uint) mode);
            this.vmethod_1();
        }

        public void MatrixMode(uint mode)
        {
            this.vmethod_0();
            glMatrixMode(mode);
            this.vmethod_1();
        }

        public void method_0(uint target, int level, uint internalformat, int width, int border, uint format, uint type, byte[] pixels)
        {
            this.vmethod_0();
            glTexImage1D(target, level, internalformat, width, border, format, type, pixels);
            this.vmethod_1();
        }

        public void method_1(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, byte[] pixels)
        {
            this.vmethod_0();
            glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
            this.vmethod_1();
        }

        public void method_2(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels)
        {
            this.vmethod_0();
            glTexImage2D_1(target, level, internalformat, width, height, border, format, type, pixels);
            this.vmethod_1();
        }

        public void method_3(short[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glVertex2sv(v);
            }
            else if (v.Length == 3)
            {
                glVertex3sv(v);
            }
            else if (v.Length == 4)
            {
                glVertex4sv(v);
            }
            this.vmethod_1();
        }

        public void method_4(ref int x, ref int y)
        {
            int[] parameters = new int[4];
            this.GetInteger((uint) 0xba2, parameters);
            y = parameters[3] - y;
        }

        public void MultMatrix(double[] m)
        {
            this.vmethod_0();
            glMultMatrixd(m);
            this.vmethod_1();
        }

        public void MultMatrix(float[] m)
        {
            this.vmethod_0();
            glMultMatrixf(m);
            this.vmethod_1();
        }

        public void NewList(uint list, uint mode)
        {
            this.vmethod_0();
            glNewList(list, mode);
            this.vmethod_1();
        }

        public IntPtr NewNurbsRenderer()
        {
            this.vmethod_0();
            IntPtr ptr = gluNewNurbsRenderer();
            this.vmethod_1();
            return ptr;
        }

        public IntPtr NewQuadric()
        {
            this.vmethod_0();
            IntPtr ptr = gluNewQuadric();
            this.vmethod_1();
            return ptr;
        }

        public IntPtr NewTess()
        {
            this.vmethod_0();
            IntPtr ptr = gluNewTess();
            this.vmethod_1();
            return ptr;
        }

        public void Normal(byte[] v)
        {
            this.vmethod_0();
            glNormal3bv(v);
            this.vmethod_1();
        }

        public void Normal(double[] v)
        {
            this.vmethod_0();
            glNormal3dv(v);
            this.vmethod_1();
        }

        public void Normal(short[] v)
        {
            this.vmethod_0();
            glNormal3sv(v);
            this.vmethod_1();
        }

        public void Normal(int[] v)
        {
            this.vmethod_0();
            glNormal3iv(v);
            this.vmethod_1();
        }

        public void Normal(float[] v)
        {
            this.vmethod_0();
            glNormal3fv(v);
            this.vmethod_1();
        }

        public void Normal(byte nx, byte ny, byte nz)
        {
            this.vmethod_0();
            glNormal3b(nx, ny, nz);
            this.vmethod_1();
        }

        public void Normal(double nx, double ny, double nz)
        {
            this.vmethod_0();
            glNormal3d(nx, ny, nz);
            this.vmethod_1();
        }

        public void Normal(short nx, short ny, short nz)
        {
            this.vmethod_0();
            glNormal3s(nx, ny, nz);
            this.vmethod_1();
        }

        public void Normal(float nx, float ny, float nz)
        {
            this.vmethod_0();
            glNormal3f(nx, ny, nz);
            this.vmethod_1();
        }

        public void Normal3i(int nx, int ny, int nz)
        {
            this.vmethod_0();
            glNormal3i(nx, ny, nz);
            this.vmethod_1();
        }

        public void NormalPointer(uint type, int stride, IntPtr pointer)
        {
            this.vmethod_0();
            glNormalPointer(type, stride, pointer);
            this.vmethod_1();
        }

        public void NormalPointer(uint type, int stride, float[] pointer)
        {
            this.vmethod_0();
            glNormalPointer_1(type, stride, pointer);
            this.vmethod_1();
        }

        public void NurbsCurve(IntPtr nurbsObject, int knotsCount, float[] knots, int stride, float[] controlPointsArray, int order, uint type)
        {
            this.vmethod_0();
            gluNurbsCurve(nurbsObject, knotsCount, knots, stride, controlPointsArray, order, type);
            this.vmethod_1();
        }

        public void NurbsProperty(IntPtr nurbsObject, int property, float value)
        {
            this.vmethod_0();
            gluNurbsProperty(nurbsObject, property, value);
            this.vmethod_1();
        }

        public void NurbsSurface(IntPtr nurbsObject, int sknotsCount, float[] sknots, int tknotsCount, float[] tknots, int sStride, int tStride, float[] controlPointsArray, int sOrder, int tOrder, uint type)
        {
            this.vmethod_0();
            gluNurbsSurface(nurbsObject, sknotsCount, sknots, tknotsCount, tknots, sStride, tStride, controlPointsArray, sOrder, tOrder, type);
            this.vmethod_1();
        }

        public static void OpenGLRender(Graphics g, Action<DSkin.OpenGL.OpenGL> action)
        {
            using (DSkin.OpenGL.OpenGL ngl = new DSkin.OpenGL.OpenGL(g))
            {
                action(ngl);
            }
        }

        public void Ortho(double left, double right, double bottom, double top, double zNear, double zFar)
        {
            this.vmethod_0();
            glOrtho(left, right, bottom, top, zNear, zFar);
            this.vmethod_1();
        }

        public void Ortho2D(double left, double right, double bottom, double top)
        {
            this.vmethod_0();
            gluOrtho2D(left, right, bottom, top);
            this.vmethod_1();
        }

        public void PartialDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle)
        {
            this.vmethod_0();
            gluPartialDisk(qobj, innerRadius, outerRadius, slices, loops, startAngle, sweepAngle);
            this.vmethod_1();
        }

        public void PassThrough(float token)
        {
            this.vmethod_0();
            glPassThrough(token);
            this.vmethod_1();
        }

        public void Perspective(double fovy, double aspect, double zNear, double zFar)
        {
            this.vmethod_0();
            gluPerspective(fovy, aspect, zNear, zFar);
            this.vmethod_1();
        }

        public void PickMatrix(double x, double y, double width, double height, int[] viewport)
        {
            this.vmethod_0();
            gluPickMatrix(x, y, width, height, viewport);
            this.vmethod_1();
        }

        public void PixelMap(uint map, int mapsize, float[] values)
        {
            this.vmethod_0();
            glPixelMapfv(map, mapsize, values);
            this.vmethod_1();
        }

        public void PixelMap(uint map, int mapsize, ushort[] values)
        {
            this.vmethod_0();
            glPixelMapusv(map, mapsize, values);
            this.vmethod_1();
        }

        public void PixelMap(uint map, int mapsize, uint[] values)
        {
            this.vmethod_0();
            glPixelMapuiv(map, mapsize, values);
            this.vmethod_1();
        }

        public void PixelStore(uint pname, int param)
        {
            this.vmethod_0();
            glPixelStorei(pname, param);
            this.vmethod_1();
        }

        public void PixelStore(uint pname, float param)
        {
            this.vmethod_0();
            glPixelStoref(pname, param);
            this.vmethod_1();
        }

        public void PixelTransfer(PixelTransferParameterName pname, bool param)
        {
            this.vmethod_0();
            int num = param ? 1 : 0;
            glPixelTransferi((uint) pname, num);
            this.vmethod_1();
        }

        public void PixelTransfer(PixelTransferParameterName pname, int param)
        {
            this.vmethod_0();
            glPixelTransferi((uint) pname, param);
            this.vmethod_1();
        }

        public void PixelTransfer(PixelTransferParameterName pname, float param)
        {
            this.vmethod_0();
            glPixelTransferf((uint) pname, param);
            this.vmethod_1();
        }

        public void PixelTransfer(uint pname, bool param)
        {
            this.vmethod_0();
            int num = param ? 1 : 0;
            glPixelTransferi(pname, num);
            this.vmethod_1();
        }

        public void PixelTransfer(uint pname, int param)
        {
            this.vmethod_0();
            glPixelTransferi(pname, param);
            this.vmethod_1();
        }

        public void PixelTransfer(uint pname, float param)
        {
            this.vmethod_0();
            glPixelTransferf(pname, param);
            this.vmethod_1();
        }

        public void PixelZoom(float xfactor, float yfactor)
        {
            this.vmethod_0();
            glPixelZoom(xfactor, yfactor);
            this.vmethod_1();
        }

        public void PointSize(float size)
        {
            this.vmethod_0();
            glPointSize(size);
            this.vmethod_1();
        }

        public void PolygonMode(FaceMode face, DSkin.OpenGL.PolygonMode mode)
        {
            this.vmethod_0();
            glPolygonMode((uint) face, (uint) mode);
            this.vmethod_1();
        }

        public void PolygonMode(uint face, uint mode)
        {
            this.vmethod_0();
            glPolygonMode(face, mode);
            this.vmethod_1();
        }

        public void PolygonOffset(float factor, float units)
        {
            this.vmethod_0();
            glPolygonOffset(factor, units);
            this.vmethod_1();
        }

        public void PolygonStipple(byte[] mask)
        {
            this.vmethod_0();
            glPolygonStipple(mask);
            this.vmethod_1();
        }

        public void PopAttrib()
        {
            this.vmethod_0();
            glPopAttrib();
            this.vmethod_1();
        }

        public void PopClientAttrib()
        {
            this.vmethod_0();
            glPopClientAttrib();
            this.vmethod_1();
        }

        public void PopMatrix()
        {
            this.vmethod_0();
            glPopMatrix();
            this.vmethod_1();
        }

        public void PopName()
        {
            this.vmethod_0();
            glPopName();
            this.vmethod_1();
        }

        public void PrioritizeTextures(int n, uint[] textures, float[] priorities)
        {
            this.vmethod_0();
            glPrioritizeTextures(n, textures, priorities);
            this.vmethod_1();
        }

        public void Project(double objx, double objy, double objz, double[] modelMatrix, double[] projMatrix, int[] viewport, double[] winx, double[] winy, double[] winz)
        {
            this.vmethod_0();
            gluProject(objx, objy, objz, modelMatrix, projMatrix, viewport, winx, winy, winz);
            this.vmethod_1();
        }

        public void PushAttrib(AttributeMask mask)
        {
            this.vmethod_0();
            glPushAttrib((uint) mask);
            this.vmethod_1();
        }

        public void PushAttrib(uint mask)
        {
            this.vmethod_0();
            glPushAttrib(mask);
            this.vmethod_1();
        }

        public void PushClientAttrib(uint mask)
        {
            this.vmethod_0();
            glPushClientAttrib(mask);
            this.vmethod_1();
        }

        public void PushMatrix()
        {
            this.vmethod_0();
            glPushMatrix();
            this.vmethod_1();
        }

        public void PushName(uint name)
        {
            this.vmethod_0();
            glPushName(name);
            this.vmethod_1();
        }

        public void PwlCurve(IntPtr nobj, int count, float array, int stride, uint type)
        {
            this.vmethod_0();
            gluPwlCurve(nobj, count, array, stride, type);
            this.vmethod_1();
        }

        public void QuadricDrawStyle(IntPtr quadObject, uint drawStyle)
        {
            this.vmethod_0();
            gluQuadricDrawStyle(quadObject, drawStyle);
            this.vmethod_1();
        }

        public void QuadricNormals(IntPtr quadricObject, uint normals)
        {
            this.vmethod_0();
            gluQuadricNormals(quadricObject, normals);
            this.vmethod_1();
        }

        public void QuadricOrientation(IntPtr quadricObject, int orientation)
        {
            this.vmethod_0();
            gluQuadricOrientation(quadricObject, orientation);
            this.vmethod_1();
        }

        public void QuadricTexture(IntPtr quadricObject, int textureCoords)
        {
            this.vmethod_0();
            gluQuadricTexture(quadricObject, textureCoords);
            this.vmethod_1();
        }

        public void RasterPos(double[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glRasterPos2dv(v);
            }
            else if (v.Length == 3)
            {
                glRasterPos3dv(v);
            }
            else
            {
                glRasterPos4dv(v);
            }
            this.vmethod_1();
        }

        public void RasterPos(short[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glRasterPos2sv(v);
            }
            else if (v.Length == 3)
            {
                glRasterPos3sv(v);
            }
            else
            {
                glRasterPos4sv(v);
            }
            this.vmethod_1();
        }

        public void RasterPos(int[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glRasterPos2iv(v);
            }
            else if (v.Length == 3)
            {
                glRasterPos3iv(v);
            }
            else
            {
                glRasterPos4iv(v);
            }
            this.vmethod_1();
        }

        public void RasterPos(float[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glRasterPos2fv(v);
            }
            else if (v.Length == 3)
            {
                glRasterPos3fv(v);
            }
            else
            {
                glRasterPos4fv(v);
            }
            this.vmethod_1();
        }

        public void RasterPos(double x, double y)
        {
            this.vmethod_0();
            glRasterPos2d(x, y);
            this.vmethod_1();
        }

        public void RasterPos(short x, short y)
        {
            this.vmethod_0();
            glRasterPos2s(x, y);
            this.vmethod_1();
        }

        public void RasterPos(int x, int y)
        {
            this.vmethod_0();
            glRasterPos2i(x, y);
            this.vmethod_1();
        }

        public void RasterPos(float x, float y)
        {
            this.vmethod_0();
            glRasterPos2f(x, y);
            this.vmethod_1();
        }

        public void RasterPos(double x, double y, double z)
        {
            this.vmethod_0();
            glRasterPos3d(x, y, z);
            this.vmethod_1();
        }

        public void RasterPos(short x, short y, short z)
        {
            this.vmethod_0();
            glRasterPos3s(x, y, z);
            this.vmethod_1();
        }

        public void RasterPos(int x, int y, int z)
        {
            this.vmethod_0();
            glRasterPos3i(x, y, z);
            this.vmethod_1();
        }

        public void RasterPos(float x, float y, float z)
        {
            this.vmethod_0();
            glRasterPos3f(x, y, z);
            this.vmethod_1();
        }

        public void RasterPos(double x, double y, double z, double w)
        {
            this.vmethod_0();
            glRasterPos4d(x, y, z, w);
            this.vmethod_1();
        }

        public void RasterPos(short x, short y, short z, short w)
        {
            this.vmethod_0();
            glRasterPos4s(x, y, z, w);
            this.vmethod_1();
        }

        public void RasterPos(int x, int y, int z, int w)
        {
            this.vmethod_0();
            glRasterPos4i(x, y, z, w);
            this.vmethod_1();
        }

        public void RasterPos(float x, float y, float z, float w)
        {
            this.vmethod_0();
            glRasterPos4f(x, y, z, w);
            this.vmethod_1();
        }

        public void ReadBuffer(uint mode)
        {
            this.vmethod_0();
            glReadBuffer(mode);
            this.vmethod_1();
        }

        public void ReadPixels(int x, int y, int width, int height, uint format, uint type, byte[] pixels)
        {
            this.vmethod_0();
            glReadPixels(x, y, width, height, format, type, pixels);
            this.vmethod_1();
        }

        public void ReadPixels(int x, int y, int width, int height, uint format, uint type, IntPtr pixels)
        {
            this.vmethod_0();
            glReadPixels_1(x, y, width, height, format, type, pixels);
            this.vmethod_1();
        }

        public void Rect(double[] v1, double[] v2)
        {
            this.vmethod_0();
            glRectdv(v1, v2);
            this.vmethod_1();
        }

        public void Rect(short[] v1, short[] v2)
        {
            this.vmethod_0();
            glRectsv(v1, v2);
            this.vmethod_1();
        }

        public void Rect(int[] v1, int[] v2)
        {
            this.vmethod_0();
            glRectiv(v1, v2);
            this.vmethod_1();
        }

        public void Rect(float[] v1, float[] v2)
        {
            this.vmethod_0();
            glRectfv(v1, v2);
            this.vmethod_1();
        }

        public void Rect(double x1, double y1, double x2, double y2)
        {
            this.vmethod_0();
            glRectd(x1, y1, x2, y2);
            this.vmethod_1();
        }

        public void Rect(short x1, short y1, short x2, short y2)
        {
            this.vmethod_0();
            glRects(x1, y1, x2, y2);
            this.vmethod_1();
        }

        public void Rect(int x1, int y1, int x2, int y2)
        {
            this.vmethod_0();
            glRecti(x1, y1, x2, y2);
            this.vmethod_1();
        }

        public void Rect(float x1, float y1, float x2, float y2)
        {
            this.vmethod_0();
            glRectd((double) x1, (double) y1, (double) x2, (double) y2);
            this.vmethod_1();
        }

        public int RenderMode(RenderingMode mode)
        {
            this.vmethod_0();
            int num = glRenderMode((uint) mode);
            this.vmethod_1();
            return num;
        }

        public int RenderMode(uint mode)
        {
            this.vmethod_0();
            int num = glRenderMode(mode);
            this.vmethod_1();
            return num;
        }

        public void Rotate(float anglex, float angley, float anglez)
        {
            this.vmethod_0();
            glRotatef(anglex, 1f, 0f, 0f);
            glRotatef(angley, 0f, 1f, 0f);
            glRotatef(anglez, 0f, 0f, 1f);
            this.vmethod_1();
        }

        public void Rotate(double angle, double x, double y, double z)
        {
            this.vmethod_0();
            glRotated(angle, x, y, z);
            this.vmethod_1();
        }

        public void Rotate(float angle, float x, float y, float z)
        {
            this.vmethod_0();
            glRotatef(angle, x, y, z);
            this.vmethod_1();
        }

        public void Scale(double x, double y, double z)
        {
            this.vmethod_0();
            glScaled(x, y, z);
            this.vmethod_1();
        }

        public void Scale(float x, float y, float z)
        {
            this.vmethod_0();
            glScalef(x, y, z);
            this.vmethod_1();
        }

        public void ScaleImage(int format, int widthin, int heightin, int typein, int[] datain, int widthout, int heightout, int typeout, int[] dataout)
        {
            this.vmethod_0();
            gluScaleImage(format, widthin, heightin, typein, datain, widthout, heightout, typeout, dataout);
            this.vmethod_1();
        }

        public void Scissor(int x, int y, int width, int height)
        {
            this.vmethod_0();
            glScissor(x, y, width, height);
            this.vmethod_1();
        }

        public void SelectBuffer(int size, uint[] buffer)
        {
            this.vmethod_0();
            glSelectBuffer(size, buffer);
            this.vmethod_1();
        }

        public void ShadeModel(DSkin.OpenGL.ShadeModel mode)
        {
            this.vmethod_0();
            glShadeModel((uint) mode);
            this.vmethod_1();
        }

        public void ShadeModel(uint mode)
        {
            this.vmethod_0();
            glShadeModel(mode);
            this.vmethod_1();
        }

        public void Sphere(IntPtr qobj, double radius, int slices, int stacks)
        {
            this.vmethod_0();
            gluSphere(qobj, radius, slices, stacks);
            this.vmethod_1();
        }

        public void StencilFunc(StencilFunction func, int reference, uint mask)
        {
            this.vmethod_0();
            glStencilFunc((uint) func, reference, mask);
            this.vmethod_1();
        }

        public void StencilFunc(uint func, int reference, uint mask)
        {
            this.vmethod_0();
            glStencilFunc(func, reference, mask);
            this.vmethod_1();
        }

        public void StencilMask(uint mask)
        {
            this.vmethod_0();
            glStencilMask(mask);
            this.vmethod_1();
        }

        public void StencilOp(StencilOperation fail, StencilOperation zfail, StencilOperation zpass)
        {
            this.vmethod_0();
            glStencilOp((uint) fail, (uint) zfail, (uint) zpass);
            this.vmethod_1();
        }

        public void StencilOp(uint fail, uint zfail, uint zpass)
        {
            this.vmethod_0();
            glStencilOp(fail, zfail, zpass);
            this.vmethod_1();
        }

        public void SwapBuffers()
        {
            if (this.intptr_1 != IntPtr.Zero)
            {
                DSkin.NativeMethods.SwapBuffers(this.intptr_1);
            }
        }

        public void TessBeginContour(IntPtr tess)
        {
            this.vmethod_0();
            gluTessBeginContour(tess);
        }

        public void TessBeginPolygon(IntPtr tess, IntPtr polygonData)
        {
            this.vmethod_0();
            gluTessBeginPolygon(tess, polygonData);
            this.vmethod_1();
        }

        public void TessEndContour(IntPtr tess)
        {
            this.vmethod_0();
            gluTessEndContour(tess);
            this.vmethod_1();
        }

        public void TessEndPolygon(IntPtr tess)
        {
            this.vmethod_0();
            gluTessEndPolygon(tess);
            this.vmethod_1();
        }

        public void TessNormal(IntPtr tess, double x, double y, double z)
        {
            this.vmethod_0();
            gluTessNormal(tess, x, y, z);
            this.vmethod_1();
        }

        public void TessProperty(IntPtr tess, int which, double value)
        {
            this.vmethod_0();
            gluTessProperty(tess, which, value);
            this.vmethod_1();
        }

        public void TessVertex(IntPtr tess, double[] coords, double[] data)
        {
            this.vmethod_0();
            gluTessVertex(tess, coords, data);
            this.vmethod_1();
        }

        public void TexCoord(double s)
        {
            this.vmethod_0();
            glTexCoord1d(s);
            this.vmethod_1();
        }

        public void TexCoord(double[] v)
        {
            this.vmethod_0();
            if (v.Length == 1)
            {
                glTexCoord1dv(v);
            }
            else if (v.Length == 2)
            {
                glTexCoord2dv(v);
            }
            else if (v.Length == 3)
            {
                glTexCoord3dv(v);
            }
            else if (v.Length == 4)
            {
                glTexCoord4dv(v);
            }
            this.vmethod_1();
        }

        public void TexCoord(float[] v)
        {
            this.vmethod_0();
            if (v.Length == 1)
            {
                glTexCoord1fv(v);
            }
            else if (v.Length == 2)
            {
                glTexCoord2fv(v);
            }
            else if (v.Length == 3)
            {
                glTexCoord3fv(v);
            }
            else if (v.Length == 4)
            {
                glTexCoord4fv(v);
            }
            this.vmethod_1();
        }

        public void TexCoord(short s)
        {
            this.vmethod_0();
            glTexCoord1s(s);
            this.vmethod_1();
        }

        public void TexCoord(int s)
        {
            this.vmethod_0();
            glTexCoord1i(s);
            this.vmethod_1();
        }

        public void TexCoord(float s)
        {
            this.vmethod_0();
            glTexCoord1f(s);
            this.vmethod_1();
        }

        public void TexCoord(short[] v)
        {
            this.vmethod_0();
            if (v.Length == 1)
            {
                glTexCoord1sv(v);
            }
            else if (v.Length == 2)
            {
                glTexCoord2sv(v);
            }
            else if (v.Length == 3)
            {
                glTexCoord3sv(v);
            }
            else if (v.Length == 4)
            {
                glTexCoord4sv(v);
            }
            this.vmethod_1();
        }

        public void TexCoord(int[] v)
        {
            this.vmethod_0();
            if (v.Length == 1)
            {
                glTexCoord1iv(v);
            }
            else if (v.Length == 2)
            {
                glTexCoord2iv(v);
            }
            else if (v.Length == 3)
            {
                glTexCoord3iv(v);
            }
            else if (v.Length == 4)
            {
                glTexCoord4iv(v);
            }
            this.vmethod_1();
        }

        public void TexCoord(double s, double t)
        {
            this.vmethod_0();
            glTexCoord2d(s, t);
            this.vmethod_1();
        }

        public void TexCoord(short s, short t)
        {
            this.vmethod_0();
            glTexCoord2s(s, t);
            this.vmethod_1();
        }

        public void TexCoord(int s, int t)
        {
            this.vmethod_0();
            glTexCoord2i(s, t);
            this.vmethod_1();
        }

        public void TexCoord(float s, float t)
        {
            this.vmethod_0();
            glTexCoord2f(s, t);
            this.vmethod_1();
        }

        public void TexCoord(double s, double t, double r)
        {
            this.vmethod_0();
            glTexCoord3d(s, t, r);
            this.vmethod_1();
        }

        public void TexCoord(short s, short t, short r)
        {
            this.vmethod_0();
            glTexCoord3s(s, t, r);
            this.vmethod_1();
        }

        public void TexCoord(int s, int t, int r)
        {
            this.vmethod_0();
            glTexCoord3i(s, t, r);
            this.vmethod_1();
        }

        public void TexCoord(float s, float t, float r)
        {
            this.vmethod_0();
            glTexCoord3f(s, t, r);
            this.vmethod_1();
        }

        public void TexCoord(double s, double t, double r, double q)
        {
            this.vmethod_0();
            glTexCoord4d(s, t, r, q);
            this.vmethod_1();
        }

        public void TexCoord(short s, short t, short r, short q)
        {
            this.vmethod_0();
            glTexCoord4s(s, t, r, q);
            this.vmethod_1();
        }

        public void TexCoord(int s, int t, int r, int q)
        {
            this.vmethod_0();
            glTexCoord4i(s, t, r, q);
            this.vmethod_1();
        }

        public void TexCoord(float s, float t, float r, float q)
        {
            this.vmethod_0();
            glTexCoord4f(s, t, r, q);
            this.vmethod_1();
        }

        public void TexCoordPointer(int size, uint type, int stride, IntPtr pointer)
        {
            this.vmethod_0();
            glTexCoordPointer(size, type, stride, pointer);
            this.vmethod_1();
        }

        public void TexCoordPointer(int size, uint type, int stride, float[] pointer)
        {
            this.vmethod_0();
            glTexCoordPointer_1(size, type, stride, pointer);
            this.vmethod_1();
        }

        public void TexEnv(uint target, uint pname, int param)
        {
            this.vmethod_0();
            glTexEnvi(target, pname, param);
            this.vmethod_1();
        }

        public void TexEnv(uint target, uint pname, float param)
        {
            this.vmethod_0();
            glTexEnvf(target, pname, param);
            this.vmethod_1();
        }

        public void TexEnv(uint target, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glTexGeniv(target, pname, parameters);
            this.vmethod_1();
        }

        public void TexEnv(uint target, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glTexEnvfv(target, pname, parameters);
            this.vmethod_1();
        }

        public void TexGen(uint coord, uint pname, double param)
        {
            this.vmethod_0();
            glTexGend(coord, pname, param);
            this.vmethod_1();
        }

        public void TexGen(uint coord, uint pname, double[] parameters)
        {
            this.vmethod_0();
            glTexGendv(coord, pname, parameters);
            this.vmethod_1();
        }

        public void TexGen(uint coord, uint pname, int param)
        {
            this.vmethod_0();
            glTexGeni(coord, pname, param);
            this.vmethod_1();
        }

        public void TexGen(uint coord, uint pname, float param)
        {
            this.vmethod_0();
            glTexGenf(coord, pname, param);
            this.vmethod_1();
        }

        public void TexGen(uint coord, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glTexGeniv(coord, pname, parameters);
            this.vmethod_1();
        }

        public void TexGen(uint coord, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glTexGenfv(coord, pname, parameters);
            this.vmethod_1();
        }

        public void TexParameter(TextureTarget target, TextureParameter pname, float param)
        {
            this.vmethod_0();
            glTexParameterf((uint) target, (uint) pname, param);
            this.vmethod_1();
        }

        public void TexParameter(TextureTarget target, TextureParameter pname, int[] parameters)
        {
            this.vmethod_0();
            glTexParameteriv((uint) target, (uint) pname, parameters);
            this.vmethod_1();
        }

        public void TexParameter(TextureTarget target, TextureParameter pname, float[] parameters)
        {
            this.vmethod_0();
            glTexParameterfv((uint) target, (uint) pname, parameters);
            this.vmethod_1();
        }

        public void TexParameter(TextureTarget target, TextureParameter pname, int param)
        {
            this.vmethod_0();
            glTexParameteri((uint) target, (uint) pname, param);
            this.vmethod_1();
        }

        public void TexParameter(uint target, uint pname, int param)
        {
            this.vmethod_0();
            glTexParameteri(target, pname, param);
            this.vmethod_1();
        }

        public void TexParameter(uint target, uint pname, float param)
        {
            this.vmethod_0();
            glTexParameterf(target, pname, param);
            this.vmethod_1();
        }

        public void TexParameter(uint target, uint pname, int[] parameters)
        {
            this.vmethod_0();
            glTexParameteriv(target, pname, parameters);
            this.vmethod_1();
        }

        public void TexParameter(uint target, uint pname, float[] parameters)
        {
            this.vmethod_0();
            glTexParameterfv(target, pname, parameters);
            this.vmethod_1();
        }

        public void TexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, int[] pixels)
        {
            this.vmethod_0();
            glTexSubImage1D(target, level, xoffset, width, format, type, pixels);
            this.vmethod_1();
        }

        public void TexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, int[] pixels)
        {
            this.vmethod_0();
            glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
            this.vmethod_1();
        }

        public void Translate(double x, double y, double z)
        {
            this.vmethod_0();
            glTranslated(x, y, z);
            this.vmethod_1();
        }

        public void Translate(float x, float y, float z)
        {
            this.vmethod_0();
            glTranslatef(x, y, z);
            this.vmethod_1();
        }

        public double[] UnProject(double winx, double winy, double winz)
        {
            this.vmethod_0();
            double[] parameters = new double[0x10];
            double[] numArray2 = new double[0x10];
            int[] numArray3 = new int[4];
            this.GetDouble((uint) 0xba6, parameters);
            this.GetDouble((uint) 0xba7, numArray2);
            this.GetInteger((uint) 0xba2, numArray3);
            double[] numArray4 = new double[3];
            gluUnProject(winx, winy, winz, parameters, numArray2, numArray3, ref numArray4[0], ref numArray4[1], ref numArray4[2]);
            this.vmethod_1();
            return numArray4;
        }

        public void UnProject(double winx, double winy, double winz, double[] modelMatrix, double[] projMatrix, int[] viewport, ref double objx, ref double objy, ref double objz)
        {
            this.vmethod_0();
            gluUnProject(winx, winy, winz, modelMatrix, projMatrix, viewport, ref objx, ref objy, ref objz);
            this.vmethod_1();
        }

        public void Vertex(double[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glVertex2dv(v);
            }
            else if (v.Length == 3)
            {
                glVertex3dv(v);
            }
            else if (v.Length == 4)
            {
                glVertex4dv(v);
            }
            this.vmethod_1();
        }

        public void Vertex(int[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glVertex2iv(v);
            }
            else if (v.Length == 3)
            {
                glVertex3iv(v);
            }
            else if (v.Length == 4)
            {
                glVertex4iv(v);
            }
            this.vmethod_1();
        }

        public void Vertex(float[] v)
        {
            this.vmethod_0();
            if (v.Length == 2)
            {
                glVertex2fv(v);
            }
            else if (v.Length == 3)
            {
                glVertex3fv(v);
            }
            else if (v.Length == 4)
            {
                glVertex4fv(v);
            }
            this.vmethod_1();
        }

        public void Vertex(double x, double y)
        {
            this.vmethod_0();
            glVertex2d(x, y);
            this.vmethod_1();
        }

        public void Vertex(short x, short y)
        {
            this.vmethod_0();
            glVertex2s(x, y);
            this.vmethod_1();
        }

        public void Vertex(int x, int y)
        {
            this.vmethod_0();
            glVertex2i(x, y);
            this.vmethod_1();
        }

        public void Vertex(float x, float y)
        {
            this.vmethod_0();
            glVertex2f(x, y);
            this.vmethod_1();
        }

        public void Vertex(double x, double y, double z)
        {
            this.vmethod_0();
            glVertex3d(x, y, z);
            this.vmethod_1();
        }

        public void Vertex(short x, short y, short z)
        {
            this.vmethod_0();
            glVertex3s(x, y, z);
            this.vmethod_1();
        }

        public void Vertex(int x, int y, int z)
        {
            this.vmethod_0();
            glVertex3i(x, y, z);
            this.vmethod_1();
        }

        public void Vertex(float x, float y, float z)
        {
            this.vmethod_0();
            glVertex3f(x, y, z);
            this.vmethod_1();
        }

        public void Vertex4d(double x, double y, double z, double w)
        {
            this.vmethod_0();
            glVertex4d(x, y, z, w);
            this.vmethod_1();
        }

        public void Vertex4f(float x, float y, float z, float w)
        {
            this.vmethod_0();
            glVertex4f(x, y, z, w);
            this.vmethod_1();
        }

        public void Vertex4i(int x, int y, int z, int w)
        {
            this.vmethod_0();
            glVertex4i(x, y, z, w);
            this.vmethod_1();
        }

        public void Vertex4s(short x, short y, short z, short w)
        {
            this.vmethod_0();
            glVertex4s(x, y, z, w);
            this.vmethod_1();
        }

        public void VertexPointer(int size, int stride, double[] pointer)
        {
            this.vmethod_0();
            glVertexPointer_4(size, 0x140a, stride, pointer);
            this.vmethod_1();
        }

        public void VertexPointer(int size, int stride, short[] pointer)
        {
            this.vmethod_0();
            glVertexPointer_1(size, 0x1402, stride, pointer);
            this.vmethod_1();
        }

        public void VertexPointer(int size, int stride, int[] pointer)
        {
            this.vmethod_0();
            glVertexPointer_2(size, 0x1404, stride, pointer);
            this.vmethod_1();
        }

        public void VertexPointer(int size, int stride, float[] pointer)
        {
            this.vmethod_0();
            glVertexPointer_3(size, 0x1406, stride, pointer);
            this.vmethod_1();
        }

        public void VertexPointer(int size, uint type, int stride, IntPtr pointer)
        {
            this.vmethod_0();
            glVertexPointer(size, type, stride, pointer);
            this.vmethod_1();
        }

        public void Viewport(int x, int y, int width, int height)
        {
            this.vmethod_0();
            glViewport(x, y, width, height);
            this.vmethod_1();
        }

        protected virtual void vmethod_0()
        {
        }

        protected virtual void vmethod_1()
        {
        }

        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern IntPtr wglCreateContext(IntPtr hdc);
        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern int wglDeleteContext(IntPtr hrc);
        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern IntPtr wglGetCurrentContext();
        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern IntPtr wglGetProcAddress(string name);
        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern int wglMakeCurrent(IntPtr hdc, IntPtr hrc);
        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern bool wglShareLists(IntPtr hrc1, IntPtr hrc2);
        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern bool wglUseFontBitmaps(IntPtr hDC, uint first, uint count, uint listBase);
        [DllImport("opengl32.dll", SetLastError=true)]
        public static extern bool wglUseFontOutlines(IntPtr hDC, uint first, uint count, uint listBase, float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] GLYPHMETRICSFLOAT[] lpgmf);

        public string Extensions
        {
            get
            {
                return this.GetString((uint) 0x1f03);
            }
        }

        public string Renderer
        {
            get
            {
                return this.GetString((uint) 0x1f01);
            }
        }

        public string Vendor
        {
            get
            {
                return this.GetString((uint) 0x1f00);
            }
        }

        public string Version
        {
            get
            {
                return this.GetString((uint) 0x1f02);
            }
        }
    }
}

