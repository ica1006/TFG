﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPlantaPiloto
{
    public static class SpanishText
    {
        // Labels
        public static string lbl_ConString { get; } = "Base de datos - Connection String";
        public static string lbl_Connection { get; } = "Base de datos conectada: ";
        public static string btn_ConnString { get; } = "Conectar";
        public static string linkButtonFullDB { get; } = "Ver BD completa";
        public static string lbl_Project { get; } = "Proyecto: ";
        public static string gview1Col1 { get; } = "Variables";
        public static string gview1Col2 { get; } = "Valores";
        public static string lbl_ChangeVariable { get; } = "Cambiar variables";
        public static string btn_ChangeVar { get; } = "Cambiar";
        public static string lbl_ChangeData { get; } = "Cantidad de datos";
        public static string btn_ChangeData { get; } = "Actualizar";
        public static string lbl_Options { get; } = "Opciones";
        public static string lbl_Language { get; } = "Idioma";
        public static string lbl_Theme { get; } = "Tema";
        public static string ddlist_langLang1 { get; } = "Español";
        public static string ddlist_langLang2 { get; } = "Inglés";
        public static string ddlist_themeTheme1 { get; } = "Claro";
        public static string ddlist_themeTheme2 { get; } = "Oscuro";

        // Exceptions && Errors
        public static string lbl_err_ConStringEx1 { get; } = "Error, por favor introduce un connection string válido";
        public static string lbl_err_ConStringEx2 { get; } = "Error cargando el proyecto ";
        public static string lbl_err_tableEx1 { get; } = "Error cargando la tabla ";
        public static string lbl_err_tableEx2 { get; } = "Error actualizando la tabla ";
        public static string lbl_err_ChartEx1 { get; } = "Error cargando el gráfico ";
        public static string lbl_err_ChartEx2 { get; } = "Error intentando obtener las casillas marcadas ";
        public static string lbl_err_ChangeDataEx1 { get; } = "Error, por favor introduce un número natural válido";
        public static string lbl_err_ChangeVarEx1 { get; } = "Error, please enter only natural or decimal numbers";
        public static string lbl_err_ChangeVarEx2 { get; } = "Error cambiando la variable ";
    }
}