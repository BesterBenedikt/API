using System.Collections.Generic;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

public class BootstrapTeamDropDown
{
    public static MvcHtmlString Dropdown(string id, List<Domain.T001_Teams> selectListItems, int selectedId = 0)
    {

        return new MvcHtmlString(BuildDropdown(id.ToString(), selectListItems,selectedId));
    }

    private static string BuildDropdown(string id, IEnumerable<Domain.T001_Teams> items, int selectedId)
    {

        var select = new TagBuilder("select")
        {
            Attributes =
            {
                { "class", "form-control"},
                 { "name", id.ToString()}
            }
        };

        foreach (var item in items)
        {
            TagBuilder option;
            if (item.Id == selectedId)
            {
                option = new TagBuilder("option")

                {
                    Attributes =
            {
                {"id", item.Id.ToString()},
                 {"value", item.Name},
                        {"selected", "selected" }

            }
                };
            }

            else
            {
                option = new TagBuilder("option")

                {
                    Attributes =
            {
                {"id", item.Id.ToString()},
                 {"value", item.Name}

            }
                };


            };

            option.InnerHtml += item.Name;
            select.InnerHtml += option;
        }

        return select.ToString();
    }


}