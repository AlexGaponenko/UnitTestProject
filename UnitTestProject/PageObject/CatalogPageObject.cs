﻿using OpenQA.Selenium;
using UnitTestProject.Core.SeleniumMethods;

namespace UnitTestProject.PageObject
{
    public class CatalogPageObject
    {

        private ButtonOne button = new ButtonOne();
        private readonly By _allCatalog = By.CssSelector(".b-main-navigation");

        public void getCatalogObject()
        {
            button.countElements(_allCatalog);
        }
    }
}
