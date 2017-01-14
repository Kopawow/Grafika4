using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace zad4
{
  class PasekMenu : Panel
  {

    ContextMenu menu;
    Menu plik;
    public MenuItem wczytajScene;
    public MenuItem wczytajKamere;
    public MenuItem zapiszKamere;
    public MenuItem zakoncz;
    Menu opcje;
    public MenuItem wPersp;
    public MenuItem settings;
    public Form _form;

    public PasekMenu(Form form)
    {
      _form = form;
    menu = new ContextMenu();
    plik = new MainMenu()
    {
      Name = "Plik"
    };
    wczytajScene = new MenuItem("Wczytaj scenę");
    wczytajKamere = new MenuItem("Wczytaj kamerę");
    zapiszKamere = new MenuItem("Zapisz kamerę");
    zakoncz = new MenuItem("Zakończ");
    plik.MenuItems.Add(wczytajScene);
    plik.MenuItems.Add(wczytajKamere);
    plik.MenuItems.Add(zapiszKamere);
    plik.MenuItems.Add(zakoncz);
    opcje = new MainMenu()
    {
      Name = "Opcje"
    };
    wPersp = new MenuItem("Rzut perspektywiczny/prosty");
    settings = new MenuItem("Ustawienia");
    opcje.MenuItems.Add(wPersp);
    opcje.MenuItems.Add(settings);
      MenuItem[] arraItems = new MenuItem[plik.MenuItems.Count];
      MenuItem[] arra2Items = new MenuItem[opcje.MenuItems.Count];
      plik.MenuItems.CopyTo(arraItems, 0);
      opcje.MenuItems.CopyTo(arra2Items, 0);
    menu.MenuItems.Add(plik.Name, arraItems);
    menu.MenuItems.Add(opcje.Name, arra2Items);
    _form.ContextMenu = menu;
  }

        //  public void paintComponent(Graphics g)
  //{
  //  super.paintComponent(g);
  //  _form.setLayout(null);
  //  menu.setBounds(0, 0, _form.Width, _form.Height);
  //}
}
}