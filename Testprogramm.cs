using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

var mitarbeiter = new Mitarbeiter(
    "Michael",
    "Georgoulis",
    4711,
    3500m
    

);

Console.WriteLine(mitarbeiter.Vorname);
Console.WriteLine(mitarbeiter.Monatsgehalt + "Euro");

mitarbeiter.ErhoeheGehalt(500m);
mitarbeiter.ErhoeheGehalt(500m);
Console.WriteLine(mitarbeiter.Monatsgehalt + " Euro");

try
{
    mitarbeiter.ErhoeheGehalt(-500m);

}
catch (ArgumentOutOfRangeException ex)
{

    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ParamName);
}

var auftrag1 = new Auftrag(
    "4711",
    "Liebherr",
    125.75,
    true
);

var auftrag2 = new Auftrag(
    "4567",
    "Liebherr",
    245.00,
    false
);

var auftrag3 = new Auftrag(
    "3690",
    "Liebherr",
    124.55,
    false
);

var auftraege = new List<Auftrag>();

auftraege.Add(auftrag1);
auftraege.Add(auftrag2);
auftraege.Add(auftrag3);

Console.WriteLine();

/*foreach (Auftrag auftrag in auftraege)
{
    Console.WriteLine($"Auftrag {auftraege.IndexOf(auftrag)+1}");
    Console.WriteLine($"Auftragsnummer: {auftrag.Auftragsnummer}");
    Console.WriteLine($"Kunde: {auftrag.Kunde}");
    Console.WriteLine($"Versandgewicht: {auftrag.Gewicht} kg");
    Console.WriteLine($"Auftragsstatus: {auftrag.StatusPruefen()}");
    Console.WriteLine("-----------------------");
}*/

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

double gesamtgewicht = 0;
double durchschnittsGewicht = 0;

for (int i = 0; i < auftraege.Count; i++)
{
    gesamtgewicht += auftraege[i].Gewicht;
    
}

durchschnittsGewicht = gesamtgewicht / auftraege.Count;

Console.WriteLine($"Gesamtgewicht der Aufträge 😂: {gesamtgewicht:F2} kg.");
Console.WriteLine($"Durchschnittliches Auftragsgewicht: {durchschnittsGewicht} kg.");

bool eingabeGueltig = false;
double neuesGewicht = 0;

do
{ 
    Console.Write("Neues Gewicht eingeben: ");

    string Eingabe = Console.ReadLine();
    
    try
    { 
        double.Parse(Eingabe);
        
        auftrag1.GewichtAendern(double.Parse(Eingabe));

        eingabeGueltig = true;   
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"{ex.Message} \n-> Die Eingabe darf nur einen Zahlenwert enthalten.");
        Console.Write("Bitte eine neue Eingabe des Gewichts: ");
    }
    
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"{ex.Message} \n-> Die Eingabe liegt außerhalb des gültigen Wertebereichs.");
        Console.WriteLine("Bitte geben sie einen gültigen Wert ein: ");
    }
    
}

while (!eingabeGueltig);


/*Console.WriteLine($"Kunde: {auftrag1.Kunde}");
Console.WriteLine($"Auftragsnummer: {auftrag1.Auftragsnummer}");
Console.WriteLine($"Gewicht: {auftrag1.Gewicht} kg");
Console.WriteLine($"Auftragstatus: {auftrag1.StatusPruefen()}");

auftrag1.AuftragAbschliessen();
Console.WriteLine($"Auftragstatus: {auftrag1.StatusPruefen()}");

auftrag1.AuftragAbschliessen();
Console.WriteLine($"Auftragstatus: {auftrag1.StatusPruefen()}");


//Tests für Gewichtsänderung

auftrag1.GewichtAendern(235.50);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht} kg");

auftrag1.GewichtAendern(-235.50);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht} kg");

auftrag1.GewichtAendern(0);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht} kg");

auftrag1.GewichtAendern(1.4);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht} kg");

// Tests für die Versandkostenberechnung

Console.WriteLine($"Es werden Versandkosten in Höhe von {auftrag1.VersandkostenBerechnen()}€ für ein Sendungsgewicht von {auftrag1.Gewicht}kg fällig.");

auftrag1.GewichtAendern(500.5);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht} kg");

Console.WriteLine($"Es werden Versandkosten in Höhe von {auftrag1.VersandkostenBerechnen()}€ für ein Sendungsgewicht von {auftrag1.Gewicht}kg fällig.");

auftrag1.GewichtAendern(100);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht}kg");

Console.WriteLine($"Es werden Versandkosten in Höhe von {auftrag1.VersandkostenBerechnen()}€ für ein Sendungsgewicht von {auftrag1.Gewicht}kg fällig.");

//Schwerlast Tests 

if (auftrag1.IstSchwerlast())
{
    Console.WriteLine("Schwerlastauftrag");
}
else
{
    Console.WriteLine("Normaler Auftrag");
}

auftrag1.GewichtAendern(250);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht}kg");
if (auftrag1.IstSchwerlast())
{
    Console.WriteLine("Schwerlastauftrag");
}
else
{
    Console.WriteLine("Normaler Auftrag");
}

auftrag1.GewichtAendern(251);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht}kg");
if (auftrag1.IstSchwerlast())
{
    Console.WriteLine("Schwerlastauftrag");
}
else
{
    Console.WriteLine("Normaler Auftrag");
}

auftrag1.GewichtAendern(2000);
Console.WriteLine($"Gewicht: {auftrag1.Gewicht}kg");
if (auftrag1.IstSchwerlast())
{
    Console.WriteLine("Schwerlastauftrag");
}
else
{
    Console.WriteLine("Normaler Auftrag");
}

//Test für KannVersendetWerden()

Console.WriteLine($"Auftrag Versandbereit: {auftrag1.KannVersendetWerden()}");*/



/*Console.WriteLine($"Auftrag Versandbereit: {auftrag2.KannVersendetWerden()}");

// Tests für GewichstKlasseErmitteln()
// mittel start mit 245.00kg
Console.WriteLine(auftrag2.GewichtsklasseErmitteln());

auftrag2.GewichtAendern(101);
Console.WriteLine(auftrag2.GewichtsklasseErmitteln());

auftrag2.GewichtAendern(100);
Console.WriteLine(auftrag2.GewichtsklasseErmitteln());

// leicht
auftrag2.GewichtAendern(89);
Console.WriteLine(auftrag2.GewichtsklasseErmitteln());

auftrag2.GewichtAendern(250);
Console.WriteLine(auftrag2.GewichtsklasseErmitteln());

// Schwerlast
auftrag2.GewichtAendern(251);
Console.WriteLine(auftrag2.GewichtsklasseErmitteln());

auftrag2.GewichtAendern(1000);
Console.WriteLine(auftrag2.GewichtsklasseErmitteln()); */

// Test Transportpreisberechnen()
// Gültige Werte
try
{
    Console.WriteLine($"Transportpreis: {auftrag1.TransportpreisBerechnen(0.50, 10.00):F2} €");  
}
catch (ArgumentOutOfRangeException ex)
{   
    Console.WriteLine(ex.Message);
    Console.WriteLine($"Ungüliger Parameter: {ex.ParamName}");
}


// ungültiger kilopreis 
try
{
    Console.WriteLine($"Transportpreis: {auftrag1.TransportpreisBerechnen(-0.50, 10.00):F2} €");
}
catch (ArgumentOutOfRangeException ex)
{   
    Console.WriteLine(ex.Message);
    Console.WriteLine($"Ungüliger Parameter: {ex.ParamName}");
}

// ungültige Grundgebühr 
try
{
 Console.WriteLine($"Transportpreis: {auftrag1.TransportpreisBerechnen(0.50, -10.00):F2} €");
}
catch (ArgumentOutOfRangeException ex)
{   
    Console.WriteLine(ex.Message);
    Console.WriteLine($"Ungüliger Parameter: {ex.ParamName}");
}

// beide Werte ungültig (beide negativ)
// hier wird bisher nur der erste falsche Wert angezeigt. Das wird später noch verbessert.

try
{
 Console.WriteLine($"Transportpreis: {auftrag1.TransportpreisBerechnen(-0.50, -10.00):F2} €");
}
catch (ArgumentOutOfRangeException ex)
{   
    Console.WriteLine(ex.Message);
    Console.WriteLine($"Ungüliger Parameter: {ex.ParamName}");
}