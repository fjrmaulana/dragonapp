﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FajarProject.Tool
{
    public static class GeneralHelper
    {
        public static bool ValidateJSON(this string s)
        {
            try
            {
                Newtonsoft.Json.Linq.JToken.Parse(s);
                return true;
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Konversi DBNull dan null ke string
        /// </summary>
        /// <param name="value">Value yang akan di convert</param>
        /// <returns>String kosong jika value DBNull atau null</returns>
        public static string NullToString(object value)
        {
            if (value == DBNull.Value || value == null)
                return "";

            return value.ToString();
        }

        /// <summary>
        /// Konversi DBNull atau null ke string
        /// </summary>
        /// <param name="value">value yang akan diconvert</param>
        /// <param name="returnIfDBNull">String jika value adalah DBNull atau null</param>
        /// <returns></returns>
        public static string NullToString(object value, string returnIfDBNull)
        {
            if (value == DBNull.Value || value == null)
                return returnIfDBNull;

            return value.ToString();
        }

        /// <summary>
        /// Digunakan untuk parameter SQL, konversi value string ke DBNULL jika value = null
        /// </summary>
        /// <param name="value">value string</param>
        /// <param name="includeEmptyString">jika true, jika value == "" maka akan di convert ke DBNULL</param>
        /// <param name="includeWhiteSpace">jika true, jika value hanya berisi spasi (misal "  ") akan di convert ke DBNULL</param>
        /// <returns></returns>
        public static object StringToDBNull(string value, bool includeEmptyString = false, bool includeWhiteSpace = false)
        {
            switch (value)
            {
                case null:
                    return DBNull.Value;
                case "":
                    if (includeEmptyString)
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        if (includeWhiteSpace && string.IsNullOrWhiteSpace(value))
                        {
                            return DBNull.Value;
                        }
                        else
                        {
                            return value;
                        }
                    }
                default:
                    return value;
            }
        }

        /// <summary>
        /// Untuk konversi DBNull atau null ke bool, Default return false
        /// </summary>
        /// <param name="value">Value yang akan di konversi</param>
        /// <param name="valueIfNull">Default = false. Value hasil jika tipe data bukan bool / null / DBNull</param>
        /// <returns>bool value</returns>
        public static bool NullToBool(object value, bool valueIfNull = false)
        {
            bool tryBool = false;

            if (value == DBNull.Value || value == null || !bool.TryParse(value.ToString(), out tryBool))
            {
                return valueIfNull;
            }
            else
            {
                return Convert.ToBoolean(value);
            }
        }

        /// <summary>
        /// Konversi Null ke Integer
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueIfNull"></param>
        /// <returns></returns>
        public static int NullToInt(object value, int valueIfNull)
        {
            int tryValue;

            if (value == DBNull.Value || value == null || !int.TryParse(value.ToString(), out tryValue))
                return valueIfNull;
            else
                return Convert.ToInt32(value);
        }

        public static Int16 NullToInt16(object value, Int16 valueIfNull)
        {
            int tryValue;

            if (value == DBNull.Value || value == null || !int.TryParse(value.ToString(), out tryValue))
                return valueIfNull;
            else
                return Convert.ToInt16(value);
        }

        /// <summary>
        /// Konversi Null ke Double
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueIfNull"></param>
        /// <returns></returns>
        public static double NullToDouble(object value, double valueIfNull)
        {
            double tryValue;

            if (value == DBNull.Value || value == null || !double.TryParse(value.ToString(), out tryValue))
                return valueIfNull;
            else
                return Convert.ToDouble(value);
        }

        /// <summary>
        /// Konversi Null ke Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueIfNull"></param>
        /// <returns></returns>
        public static decimal NullToDecimal(object value, decimal valueIfNull)
        {
            decimal tryValue;

            if (value == DBNull.Value || value == null || !decimal.TryParse(value.ToString(), out tryValue))
                return valueIfNull;
            else
                return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Konversi Null ke Interger
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueIfNull"></param>
        /// <returns></returns>
        public static int? NullToInt(object value, int? valueIfNull)
        {
            int tryValue;

            if (value == DBNull.Value || value == null || int.TryParse(value.ToString(), out tryValue) == false)
                return valueIfNull;
            else
                return Convert.ToInt32(value);
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueIfNull"></param>
        /// <returns></returns>
        public static DateTime? NullToDateTime(object value, DateTime? valueIfNull)
        {
            DateTime tryValue;

            if (value == DBNull.Value || value == null || !DateTime.TryParse(value.ToString(), out tryValue))
                return valueIfNull;
            else
                return Convert.ToDateTime(value);
        }

        /// <summary>
        /// DetetimeOracle
        /// </summary>
        /// <param name="value"> Object Dari DataBase</param>
        /// <param name="input_konvert">Format Awal Sebelum Convert</param>
        /// <param name="output_need">Format Yang Di harapkan Setelah Convert</param>
        /// <returns></returns>
        public static DateTime DetetimeOracle(object value,string input_konvert,string output_need)
        {
            DateTime return_ = System.DateTime.Now;
            var dateToConvert = value.ToString();
            var format = input_konvert;
            try
            {
                var date = DateTime.ParseExact(dateToConvert, format, System.Globalization.CultureInfo.InvariantCulture);
                return_ = Convert.ToDateTime(date.ToString(output_need));
            }
            catch (Exception bke)
            {
                System.Diagnostics.Debug.WriteLine(bke.ToString());
                return_ = System.DateTime.Now;
            }
            return return_;
        }

        public static char NullToChar(object value, char valueIfNull)
        {
            if (value == null || value == DBNull.Value)
                return valueIfNull;

            return (char)value;
        }

        /// <summary>
        /// Konversi Null ke DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueIfNull"></param>
        /// <returns></returns>
        public static DateTime NullToDateTime(object value, DateTime valueIfNull)
        {
            DateTime tryValue;

            if (value == DBNull.Value || value == null || !DateTime.TryParse(value.ToString(), out tryValue))
                return valueIfNull;
            else
                return System.Convert.ToDateTime(value);
        }

        /// <summary>
        /// Konversi string kosong / empty menjadi DBNull (object)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object StringToDBNull(string value)
        {
            if (string.IsNullOrEmpty(value))
                return DBNull.Value;
            return value;
        }

        public static object StringToDBNull(string value, bool allowValueWhitespace)
        {
            if (value == null)
                return DBNull.Value;

            if (allowValueWhitespace && (value == "" || value == string.Empty))
                return "";
            else
                return value;
        }

        public static object IntToDBNull(object value)
        {
            int val = 0;

            if (value == null || value == DBNull.Value)
                return DBNull.Value;

            if (int.TryParse(value.ToString(), out val))
                return value;

            return DBNull.Value;
        }

        public static object IntToDBNull(object value, int valueIfNull)
        {
            int val = 0;

            if (value == null || value == DBNull.Value)
                return valueIfNull;

            if (int.TryParse(value.ToString(), out val))
                return value;

            return valueIfNull;
        }

        public static object DoubleToDBNull(object value)
        {
            double val = 0;

            if (value == null || value == DBNull.Value)
                return DBNull.Value;

            if (double.TryParse(value.ToString(), out val))
                return value;

            return DBNull.Value;
        }

        public static object DoubleToDBNull(object value, double valueIfNull)
        {
            double val = 0;

            if (value == null || value == DBNull.Value)
                return valueIfNull;

            if (double.TryParse(value.ToString(), out val))
                return value;

            return valueIfNull;
        }

        public static object DecimalToDBNull(object value)
        {
            decimal val = 0;

            if (value == null || value == DBNull.Value)
                return DBNull.Value;

            if (decimal.TryParse(value.ToString(), out val))
                return value;

            return DBNull.Value;
        }

        public static object DecimalToDBNull(object value, decimal valueIfNull)
        {
            decimal val = 0;

            if (value == null || value == DBNull.Value)
                return valueIfNull;

            if (decimal.TryParse(value.ToString(), out val))
                return value;

            return valueIfNull;
        }

        public static object FloatToDBNull(object value)
        {
            float val = 0F;

            if (value == null || value == DBNull.Value)
                return DBNull.Value;

            if (float.TryParse(value.ToString(), out val))
                return value;

            return DBNull.Value;
        }

        public static object FloatToDBNull(object value, float valueIfNull)
        {
            float val = 0F;

            if (value == null || value == DBNull.Value)
                return valueIfNull;

            if (float.TryParse(value.ToString(), out val))
                return value;

            return valueIfNull;
        }

        public static object BoolToDbNull(object value)
        {
            bool val = false;

            if (value == null || value == DBNull.Value)
                return DBNull.Value;

            if (bool.TryParse(value.ToString(), out val))
                return value;

            return DBNull.Value;
        }

        public static object BoolToDbNull(object value, bool valueIfNull)
        {
            bool val = false;

            if (value == null || value == DBNull.Value)
                return valueIfNull;

            if (bool.TryParse(value.ToString(), out val))
                return value;

            return DBNull.Value;
        }

        public static object DatetimeToDbNull(object value)
        {
            if (value == null)
                return DBNull.Value;

            if (value is DateTime)
                return Convert.ToDateTime(Convert.ToDateTime(value).ToShortDateString());
            return DBNull.Value;
        }

        public static bool? BoolToDBNull(bool? value, bool? valueIfNull)
        {
            if (value == null)
                return valueIfNull;

            return value;
        }
    }

    public static class StringExtensions
    {
        public static bool Compare(this string value, string stringToCompare, StringComparison compare)
        {
            return value?.IndexOf(stringToCompare, compare) >= 0;
        }

        public static string Left(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (length <= 0)
            {
                return value;
            }

            if (value.Length <= length)
                return value;

            return value.Substring(0, length);
        }

        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (length <= 0)
                return value;

            if (value.Length <= length)
                return value;

            return value.Substring(value.Length - length, length);
        }
    }

    public static class EnumExtensions
    {
        public static SelectList ToSelectList<T>(this T enumObj) where T : struct, IComparable, IFormattable, IConvertible
        {
            var values = from T e in Enum.GetValues(typeof(T))
                         select new { Id = (T)Enum.Parse(typeof(T), e.ToString()), Name = e.ToString().Replace("_", " ") };
            return new SelectList(values, "Id", "Name", enumObj);
        }

        public static SelectList ToSelectList<T>(this T enumObj, bool useDescription, string selectedValue) where T : struct, IComparable, IFormattable, IConvertible
        {
            if (useDescription)
            {
                var values = from T e in Enum.GetValues(typeof(T)).Cast<Enum>()
                             select new SelectListItem() { Value = Convert.ToInt32(e).ToString(), Text = (Attribute.GetCustomAttribute(e.GetType().GetField(e.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description };
                return new SelectList(values, "Value", "Text", selectedValue);
            }
            else
            {
                var values = from T e in Enum.GetValues(typeof(T)).Cast<Enum>()
                             select new SelectListItem() { Value = Convert.ToInt32(e).ToString(), Text = e.ToString().Replace("_", " ") };
                return new SelectList(values, "Value", "Text", selectedValue);
            }
        }

        public static string GetDescriptionAttribute<T>(this T obj)
        {
            string result = (string)null;

            try
            {
                if ((object)obj is Enum)
                {
                    Type type = obj.GetType();

                    foreach (int num in Enum.GetValues(type))
                    {
                        if (num == Convert.ToInt32(obj, System.Globalization.CultureInfo.InvariantCulture))
                        {
                            object[] customAttributes = type.GetMember(type.GetEnumName((object)num))[0]
                                .GetCustomAttributes(typeof(DescriptionAttribute), false);
                            if ((uint)customAttributes.Length > 0U)
                            {
                                result = ((DescriptionAttribute)customAttributes[0]).Description;
                            }

                            break;
                        }
                    }
                }

                return result;
            }
            catch
            {
                return "";
            }
        }
    }

    public static class DateTimeExtension
    {
        public static string ToPeriod(this DateTime date)
        {
            if (date == null)
                return "";

            return date.ToString("yyyyMM");
        }

        public static string MonthYearToPeriod(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            try
            {
                DateTime cDate = Convert.ToDateTime(value);
                return cDate.ToPeriod();
            }
            catch
            {
                throw;
            }


        }

        public static string GetMonthRomawi(string month)
        {
            string bln = "";

            try
            {
                if (month.Length > 0)
                {
                    switch (month)
                    {
                        case "01":
                            bln = "I";
                            break;
                        case "02":
                            bln = "II";
                            break;
                        case "03":
                            bln = "III";
                            break;
                        case "04":
                            bln = "IV";
                            break;
                        case "05":
                            bln = "V";
                            break;
                        case "06":
                            bln = "VI";
                            break;
                        case "07":
                            bln = "VII";
                            break;
                        case "08":
                            bln = "VIII";
                            break;
                        case "09":
                            bln = "IX";
                            break;
                        case "10":
                            bln = "X";
                            break;
                        case "11":
                            bln = "XI";
                            break;
                        case "12":
                            bln = "XII";
                            break;
                        default:
                            bln = "";
                            break;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

            }

            return bln;
        }

        
    }
}