﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PinYinUtils
{
    public static long GetIntSpellCode(string CnChar)
    {
        if (UIUtils.IsNull(CnChar))
        {
            return 0;
        }


        CnChar = CnChar.TrimStart();
        if (UIUtils.IsNull(CnChar))
        {
            return 0;
        }
        long iCnChar;
       
        byte[] ZW = Encoding.Default.GetBytes(CnChar);

        //如果是字母，则直接返回
        if (ZW.Length == CnChar.Length)
        {
            iCnChar = ZW[0];
        }
        else
        {
            int i1 = (short)(ZW[0]);
            int i2 = (short)(ZW[1]);
            iCnChar = i1 * 256 + i2;
        }

        return iCnChar;
    }
    /// <summary>
    /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
    /// </summary>
    /// <param name="CnChar">单个汉字</param>
    /// <returns>单个大写字母</returns>

    public static string GetCharSpellCode(string CnChar)
    {
        long iCnChar;
        CnChar = CnChar.TrimStart();
        byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

        //如果是字母，则直接返回

        if (ZW.Length == CnChar.Length)
        {
            return CnChar.Substring(0, 1).ToUpper();
        }
        else
        {
            // get the array of byte from the single char
            int i1 = (short)(ZW[0]);
            int i2 = (short)(ZW[1]);
            iCnChar = i1 * 256 + i2;
        }

        // iCnChar match the constant

        if ((iCnChar >= 45217) && (iCnChar <= 45252))
        {
            return "A";
        }

        else if ((iCnChar >= 45253) && (iCnChar <= 45760))
        {
            return "B";
        }
        else if ((iCnChar >= 45761) && (iCnChar <= 46317))
        {

            return "C";

        }
        else if ((iCnChar >= 46318) && (iCnChar <= 46825))
        {

            return "D";

        }
        else if ((iCnChar >= 46826) && (iCnChar <= 47009))
        {

            return "E";

        }
        else if ((iCnChar >= 47010) && (iCnChar <= 47296))
        {

            return "F";

        }
        else if ((iCnChar >= 47297) && (iCnChar <= 47613))
        {

            return "G";

        }
        else if ((iCnChar >= 47614) && (iCnChar <= 48118))
        {

            return "H";

        }
        else if ((iCnChar >= 48119) && (iCnChar <= 49061))
        {

            return "J";

        }
        else if ((iCnChar >= 49062) && (iCnChar <= 49323))
        {

            return "K";

        }
        else if ((iCnChar >= 49324) && (iCnChar <= 49895))
        {

            return "L";

        }
        else if ((iCnChar >= 49896) && (iCnChar <= 50370))
        {

            return "M";

        }
        else if ((iCnChar >= 50371) && (iCnChar <= 50613))
        {

            return "N";

        }
        else if ((iCnChar >= 50614) && (iCnChar <= 50621))
        {

            return "O";

        }
        else if ((iCnChar >= 50622) && (iCnChar <= 50905))
        {

            return "P";

        }
        else if ((iCnChar >= 50906) && (iCnChar <= 51386))
        {

            return "Q";

        }
        else if ((iCnChar >= 51387) && (iCnChar <= 51445))
        {

            return "R";

        }
        else if ((iCnChar >= 51446) && (iCnChar <= 52217))
        {

            return "S";

        }
        else if ((iCnChar >= 52218) && (iCnChar <= 52697))
        {

            return "T";

        }
        else if ((iCnChar >= 52698) && (iCnChar <= 52979))
        {

            return "W";

        }
        else if ((iCnChar >= 52980) && (iCnChar <= 53640))
        {

            return "X";

        }
        else if ((iCnChar >= 53689) && (iCnChar <= 54480))
        {

            return "Y";

        }
        else if ((iCnChar >= 54481) && (iCnChar <= 55289))
        {

            return "Z";

        }
        else

            return ("?");

    }




}
