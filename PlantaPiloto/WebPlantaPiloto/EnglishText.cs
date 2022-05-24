using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPlantaPiloto
{
    public static class EnglishText
    {
        // Labels
        public static string lbl_ConString { get; } = "Data Base - Connection String";
        public static string lbl_Connection { get; } = "Data Base connected: ";
        public static string btn_ConnString { get; } = "Connect";
        public static string linkButtonFullDB { get; } = "See entire database";
        public static string lbl_Project { get; } = "Project: ";
        public static string gview1Col1 { get; } = "Variables";
        public static string gview1Col2 { get; } = "Values";
        public static string lbl_ChangeVariable { get; } = "Change variables";
        public static string btn_ChangeVar { get; } = "Change";
        public static string lbl_ChangeData { get; } = "Data amount";
        public static string btn_ChangeData { get; } = "Refresh";
        public static string lbl_Options { get; } = "Options";
        public static string lbl_Language { get; } = "Language";
        public static string lbl_Theme { get; } = "Theme";
        public static string ddlist_langLang1 { get; } = "Spanish";
        public static string ddlist_langLang2 { get; } = "English";
        public static string ddlist_themeTheme1 { get; } = "Light";
        public static string ddlist_themeTheme2 { get; } = "Dark";
        public static string lbl_changesDB { get; } = "Changes Data Base";
        public static string lbl_valuesDB { get; } = "Values Data Base";
        public static string btn_back { get; } = "Back";
        public static string btn_StartStop { get; } = "Stop Auto-Refresh";
        public static string btn_StartStop2 { get; } = "Auto-Refresh";

        // Exceptions && Errors
        public static string lbl_err_ConStringEx1 { get; } = "Error, use a valid connection string please";
        public static string lbl_err_ConStringEx2 { get; } = "Error loading the proyect ";
        public static string lbl_err_tableEx1 { get; } = "Error loading the table ";
        public static string lbl_err_tableEx2 { get; } = "Error refreshing the table ";
        public static string lbl_err_ChartEx1 { get; } = "Error loading the chart ";
        public static string lbl_err_ChartEx2 { get; } = "Error trying to get the checked boxes ";
        public static string lbl_err_ChangeDataEx1 { get; } = "Error, please enter a valid positive numeric value";
        public static string lbl_err_ChangeVarEx1 { get; } = "Error, please enter only natural or decimal numbers";
        public static string lbl_err_ChangeVarEx2 { get; } = "Error changing the variable ";
    }
}