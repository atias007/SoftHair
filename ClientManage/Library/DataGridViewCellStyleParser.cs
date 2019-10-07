using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ClientManage.Library
{
    public class DataGridViewCellStyleParser
    {
        public static DataGridViewCellStyle GetCellStyle(string style)
        {
            var cellStyle = new DataGridViewCellStyle();

            style = style.Replace("DataGridViewCellStyle { ", string.Empty);
            style = style.Substring(0, style.Length - 1);
            style = SetSemiColon(style);

            var values = style.Split(';');
            TrimStringArray(ref values);

            string name;
            foreach (var val in values)
            {
                name = val.Substring(0, val.IndexOf("="));
                switch (name)
                {
                    case "BackColor":
                        cellStyle.BackColor = GetColorFromValue(val);
                        break;

                    case "ForeColor":
                        cellStyle.ForeColor = GetColorFromValue(val);
                        break;

                    case "SelectionBackColor":
                        cellStyle.SelectionBackColor = GetColorFromValue(val);
                        break;

                    case "SelectionForeColor":
                        cellStyle.SelectionForeColor = GetColorFromValue(val);
                        break;

                    case "NullValue":
                        cellStyle.NullValue = (object)GetSimpleProperty(val);
                        break;

                    case "Format":
                        cellStyle.Format = GetSimpleProperty(val);
                        break;

                    case "WrapMode":
                        cellStyle.WrapMode = (DataGridViewTriState)Enum.Parse(typeof(DataGridViewTriState), GetSimpleProperty(val));
                        break;

                    case "Alignment":
                        cellStyle.Alignment = (DataGridViewContentAlignment)Enum.Parse(typeof(DataGridViewContentAlignment), GetSimpleProperty(val));
                        break;

                    case "Padding":
                        cellStyle.Padding = GetPadding(val);
                        break;

                    case "Font":
                        cellStyle.Font = GetFont(val);
                        break;
                }
            }

            return cellStyle;
        }

        private static string GetSimpleProperty(string value)
        {
            return value.Substring(value.IndexOf("=") + 1);
        }

        private static Color GetColorFromValue(string value)
        {
            int pos1, pos2;
            Color c;
            string curValue;

            pos1 = value.IndexOf("[");
            pos2 = value.IndexOf("]");
            curValue = value.Substring(pos1 + 1, pos2 - pos1 - 1);

            if (curValue.IndexOf(",") > 0)
            {
                var rgb = curValue.Split(',');
                TrimStringArray(ref rgb);
                for (var i = 0; i < rgb.Length; i++)
                {
                    rgb[i] = GetSimpleProperty(rgb[i]);
                }
                c = Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]), Convert.ToInt32(rgb[3]));
            }
            else
            {
                c = Color.FromName(curValue);
            }
            return c;
        }

        private static void TrimStringArray(ref string[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Trim();
            }
        }

        private static Padding GetPadding(string value)
        {
            value = GetSimpleProperty(value);
            value = value.Substring(1, value.Length - 2);

            var pad = value.Split(',');
            TrimStringArray(ref pad);
            for (var i = 0; i < pad.Length; i++)
            {
                pad[i] = GetSimpleProperty(pad[i]);
            }

            return new Padding(Convert.ToInt32(pad[0]), Convert.ToInt32(pad[1]), Convert.ToInt32(pad[2]), Convert.ToInt32(pad[3]));
        }

        private static Font GetFont(string value)
        {
            value = GetSimpleProperty(value);
            value = value.Substring(1, value.Length - 2);

            var font = value.Split(',');
            TrimStringArray(ref font);
            for (var i = 0; i < font.Length; i++)
            {
                font[i] = GetSimpleProperty(font[i]);
            }

            var fontStyle = FontStyle.Regular;
            if (font.Length == 6)
            {
                font[5] = font[5].ToLower();
                if (font[5].IndexOf("b") >= 0) fontStyle = fontStyle | FontStyle.Bold;
                if (font[5].IndexOf("i") >= 0) fontStyle = fontStyle | FontStyle.Italic;
                if (font[5].IndexOf("u") >= 0) fontStyle = fontStyle | FontStyle.Underline;
                if (font[5].IndexOf("s") >= 0) fontStyle = fontStyle | FontStyle.Strikeout;
            }
            var ret = new Font(font[0], float.Parse(font[1]), fontStyle);

            return ret;
        }

        private static string SetSemiColon(string value)
        {
            var rank = 0;
            string c;

            for (var i = value.Length - 1; i >= 0; i--)
            {
                c = value.Substring(i, 1);
                if (c == "}" || c == "]") rank++;
                if (c == "{" || c == "[") rank--;
                if (c == "," && rank == 0)
                {
                    PlantSpecSemiColon(ref value, i);
                }
            }
            return value;
        }

        private static void PlantSpecSemiColon(ref string value, int pos)
        {
            value = value.Substring(0, pos) + ";" + value.Substring(pos + 1);
        }
    }
}
