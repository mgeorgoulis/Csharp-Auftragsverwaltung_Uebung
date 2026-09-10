using Microsoft.VisualBasic;

public class AuftragTests
{
    static Mitarbeiter mitarbeiter1 = new Mitarbeiter(
        "Michael",
        "Georgoulis",
        4711,
        3500m
        );

    static Auftrag auftrag1 = new Auftrag(
            "4711",
            "Liebherr",
            125.75,
            true
            );

    static Auftrag auftrag2 = new Auftrag(
            "4567",
            "Liebherr",
            245.00,
            false
        );

    static Auftrag auftrag3 = new Auftrag(
            "3690",
            "Liebherr",
            124.55,
            false
        );

    static List<Auftrag> auftraege = new List<Auftrag>()
    {
        auftrag1,
        auftrag2,
        auftrag3
    };
    
    public static void MitarbeiterDatenAnzeigen()
    {
        
        Console.WriteLine(mitarbeiter1.Vorname);
        Console.WriteLine(mitarbeiter1.Monatsgehalt + "Euro"); 
    }

    public static void ErhoeheGehaltTesten()
    {
        mitarbeiter1.ErhoeheGehalt(500m);
        mitarbeiter1.ErhoeheGehalt(500m);
        Console.WriteLine(mitarbeiter1.Monatsgehalt + " Euro");

        try
        {
            mitarbeiter1.ErhoeheGehalt(-500m);

        }
        catch (ArgumentOutOfRangeException ex)
        {

            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.ParamName);
        }  
    }

    public static void AuftraegeTesten()
    {            
        for (int i = 0; i < auftraege.Count; i++)
        {   
            Auftrag auftrag = auftraege[i];
            Console.WriteLine($"Auftrag {i+1}");
            Console.WriteLine($"Auftragsnummer: {auftrag.Auftragsnummer}");
            Console.WriteLine($"Kunde: {auftrag.Kunde}");
            Console.WriteLine($"Versandgewicht: {auftrag.Gewicht} kg");
            Console.WriteLine($"Auftragsstatus: {auftrag.StatusPruefen()}");
            Console.WriteLine("-----------------------");
        }
    }

    public static void AnzahlOffenerAuftraegeErmittelnTest()
    {
       int anzahlOffeneAuftraege = 0;

        for (int i = 0; i < auftraege.Count; i++)
        {
            Auftrag auftrag = auftraege[i];
            if (!auftrag.AuftragAbgeschlossen)
            {
                anzahlOffeneAuftraege ++;
            }
        } 
        
        Console.WriteLine($"Anzahl offener Aufträge: {anzahlOffeneAuftraege}");
    }

    public static void DurchschnittsGewichtBerechnenTest()
    {
        double gesamtgewicht = 0;
        double durchschnittsGewicht = 0;

        for (int i = 0; i < auftraege.Count; i++)
        {
            gesamtgewicht += auftraege[i].Gewicht; 
        }

        durchschnittsGewicht = gesamtgewicht / auftraege.Count;

        Console.WriteLine($"Gesamtgewicht der Aufträge 😂: {gesamtgewicht:F2} kg.");
        Console.WriteLine($"Durchschnittliches Auftragsgewicht: {durchschnittsGewicht} kg.");  
    }



    public static void TestsAusfuehren()
    {
        // hier müssen sämtliche Methodenaufrufe rein.
        MitarbeiterDatenAnzeigen();
        ErhoeheGehaltTesten();
        AuftraegeTesten();
        AnzahlOffenerAuftraegeErmittelnTest();
        DurchschnittsGewichtBerechnenTest()


    }  // Ende von TestsAusfuehren()







} // Ende der Klasse

