using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraEditors;



namespace DXSample {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
           
        }
       
        private void Form1_Load(object sender, EventArgs e) {
            radioGroup1.SelectedIndex = 2;
        }

        private static Product CreateProduct() {
            Product pr = new Product("123-12-23", "Orange", "Fruit", 12, 100);
            return pr;
        }

    
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e) {
            RadioGroup radioGroup = sender as RadioGroup;
            string cultureName = radioGroup.EditValue.ToString();

            SetCulture(cultureName);
           
            propertyGridControl1.SelectedObject = null;
            propertyGridControl1.Rows.Clear();
            propertyGridControl1.SelectedObject = CreateProduct();
        }

        private static void SetCulture(string cultureName) {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureName);
        }
    }
    
    public class Product {
        string productCode, name, category; 
        decimal price;
        int quantity;

        public Product(string code, string name, string category, decimal price, int quantity) {
            this.productCode = code;
            this.name = name;
            this.category = category;
            this.price = price;
            this.quantity = quantity;
        }
        [CustomDisplayNameAttribute("ProductCode")]
        public string ProductCode {
            get { return productCode; }
            set { productCode = value; }
        }
        [CustomDisplayNameAttribute("Name")]
        public string Name {
            get { return name; }
            set { name = value; }
        }
        [CustomDisplayNameAttribute("Category")]
        public string Category {
            get { return category; }
            set { category = value; }
        }
        [CustomDisplayNameAttribute("Price")]
        public decimal Price {
            get { return price; }
            set { price = value; }
        }
        [CustomDisplayNameAttribute("Quantity")]
        public int Quantity {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    public class CustomDisplayNameAttribute: DisplayNameAttribute {
        public CustomDisplayNameAttribute(string displayName): base(displayName) { }
        public override string DisplayName {
            get {
                return CustomLocalizer.GetLocalizedString(base.DisplayName);
            }
        }
    }


    public static class CustomLocalizer{
        public static string GetLocalizedString(string name){
            if(Thread.CurrentThread.CurrentCulture.Name == "fr-FR") {
                if(name == "ProductCode")
                    return "Produit Code";
                if(name == "Name")
                    return "Nom";
                if(name == "Category")
                    return "Catégorie";
                if(name == "Price")
                    return "Prix";
                if(name == "Quantity")
                    return "Quantité";
            }
            else
                if(Thread.CurrentThread.CurrentCulture.Name == "de-DE") {
                    if(name == "ProductCode")
                        return "Produkt Code";
                    if(name == "Name")
                        return "Name";
                    if(name == "Category")
                        return "Kategorie";
                    if(name == "Price")
                        return "Preis";
                    if(name == "Quantity")
                        return "Zahl";
                }
            return name;
        }

    }
}
       
  

  

