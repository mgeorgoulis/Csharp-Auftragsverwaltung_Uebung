public class Mitarbeiter
{
    public string Vorname  {get; set;}
    public string Nachname {get; set;}

    public int Personalnummer {get; private set;}
    public decimal Monatsgehalt {get; private set;}


    public Mitarbeiter(
        string vorname,
        string nachname,
        int personalnummer,
        decimal monatsgehalt)
    {
        Vorname = vorname;
        Nachname = nachname;
        Personalnummer = personalnummer;
        Monatsgehalt = monatsgehalt;
    }

    public void ErhoeheGehalt(decimal betrag)
    {
        if (betrag <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(betrag), 
                "Der Betrag muss größer als 0 sein.");
        }
        
        Monatsgehalt += betrag;
    }
}