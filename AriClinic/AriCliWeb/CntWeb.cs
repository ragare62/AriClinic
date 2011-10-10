using System;
using Telerik.Web.UI;

namespace AriCliWeb
{
    public static class CntWeb
    {
        public static void TranslateRadGridFilters(RadGrid rdg)
        {
            GridFilterMenu rfm = rdg.FilterMenu;
            foreach (RadMenuItem item in rfm.Items)
            {
                switch (item.Text)
                {
                    case "NoFilter":
                        item.Text = Resources.FilterResource.NoFilter;
                        break;
                    case "EqualTo":
                        item.Text = Resources.FilterResource.EqualTo;
                        break;
                    case "NotEqualTo":
                        item.Text = Resources.FilterResource.NotEqualTo;
                        break;
                    case "GreaterThan":
                        item.Text = Resources.FilterResource.GreatherThan;
                        break;
                    case "LessThan":
                        item.Text = Resources.FilterResource.LessThan;
                        break;
                    case "GreaterThanOrEqualTo":
                        item.Text = Resources.FilterResource.GreatherThanOrEqualTo;
                        break;
                    case "LessThanOrEqualTo":
                        item.Text = Resources.FilterResource.LessThanOrEqualTo;
                        break;
                    case "Between":
                        item.Text = Resources.FilterResource.Between;
                        break;
                    case "NotBetween":
                        item.Text = Resources.FilterResource.NotBetween;
                        break;
                    case "IsNull":
                        item.Text = Resources.FilterResource.IsNull;
                        break;
                    case "NotIsNull":
                        item.Text = Resources.FilterResource.NotIsNull;
                        break;

                    case "Contains":
                        item.Text = Resources.FilterResource.Contains;
                        break;
                    case "DoesNotContain":
                        item.Text = Resources.FilterResource.DoesNotContain;
                        break;
                    case "StartsWith":
                        item.Text = Resources.FilterResource.StartsWith;
                        break;
                    case "EndsWith":
                        item.Text = Resources.FilterResource.EndsWith;
                        break;
                    case "IsEmpty":
                        item.Text = Resources.FilterResource.IsEmpty;
                        break;
                    case "NotIsEmpty":
                        item.Text = Resources.FilterResource.NotIsEmpty;
                        break;
                    default:
                        break;
                }
            }
        }

        public static string PlainString(Object o)
        {
            string s = o.ToString();
            s.Replace(",", "");
            return s;
        }

        public static string GetPossibleNull(decimal? value)
        {
            if (value == null)
                return "";
            else
                return String.Format("{0:0.0###}",value);
        }
        public static decimal SetPossibleNull(string value)
        {
            if (value == "")
                return decimal.MaxValue;
            else
            {
                decimal v;
                if (decimal.TryParse(value, out v))
                    return v;
                else
                    return decimal.MaxValue;
            }
        }

    }
}