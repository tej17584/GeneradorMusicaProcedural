using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEscalas : MonoBehaviour
{

    public string note_name = "C";

    private static List<string> list_QuintasMayores = new List<string>() { "C", "G", "D", "A", "E", "B", "Gb", "Db", "Ab", "Eb", "Bb", "F" };
    private static List<string> list_QuintasMenores = new List<string>() { "Am", "Em", "Bm", "F#m", "C#m", "G#m", "Ebm", "Bbm", "Fm", "Cm", "Gm", "Dm" };

    private static List<string> listEscalaCromaticaV2 = new List<string>() { "C3", "C3#", "D3", "D3#", "E3", "F3", "F3#", "G3", "G3#", "A3", "A3#", "B3", "C4", "C4#", "D4", "D4#", "E4", "F4", "F4#", "G4", "G4#", "A4", "A4#", "B4", "C5", "C5#", "D5" };
    private static List<string> llist_EscalaCromatica = new List<string>() { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D" };

    private static Dictionary<string, string> listaNotasBasicas = new Dictionary<string, string>() {
        { "C#"  ,"Db"  },
        { "C#m" ,"Dbm" },
        { "D#"  ,"Eb"  },
        { "D#m" ,"Ebm" },
        { "F#"  ,"Gb"  },
        { "F#m" ,"Gbm" },
        { "G#"  ,"Ab"  },
        { "G#m" ,"Abm" },
        { "A#"  ,"Bb"  },
        { "A#m" ,"Bbm" },
    };

    private static Dictionary<string, string> sharpsNFlats_8ve = new Dictionary<string, string>() {
        { "C3#"  ,"D3b"  },
        { "C3#m" ,"D3bm" },
        { "D3#"  ,"E3b"  },
        { "D3#m" ,"E3bm" },
        { "F3#"  ,"G3b"  },
        { "F3#m" ,"G3bm" },
        { "G3#"  ,"A3b"  },
        { "G3#m" ,"A3bm" },
        { "A3#"  ,"B3b"  },
        { "A3#m" ,"B3bm" },

        { "C4#"  ,"D4b"  },
        { "C4#m" ,"D4bm" },
        { "D4#"  ,"E4b"  },
        { "D4#m" ,"E4bm" },
        { "F4#"  ,"G4b"  },
        { "F4#m" ,"G4bm" },
        { "G4#"  ,"A4b"  },
        { "G4#m" ,"A4bm" },
        { "A4#"  ,"B4b"  },
        { "A4#m" ,"B4bm" },
    };

    private static Dictionary<int, string> listaTonalidades = new Dictionary<int, string>() {
        { 1,"I    Tonica" },
        { 2,"II   Subdominante" },
        { 3,"III  Tonica" },
        { 4,"IV   Subdominante" },
        { 5,"V    Dominante" }, //cambiado a novena con bajo en la 5ta por que la sonoridad de maj7 no suena bien.
        { 6,"VI   Tonica" },
        { 7,"VII� Sensible" }
    };

    // Start is called before the first frame update
    void Start()
    {
        List<List<string>> chords_listt = escalaNota(note_name);
        generadorProgresiones(chords_listt);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static string getSharpsFromFlat(string val)
    {
        foreach (KeyValuePair<string, string> chord in listaNotasBasicas)
        {
            if (val.Equals(chord.Value))
            {
                return chord.Key;
            }
        }
        return "El acorde # no existe";
    }

    public static string getSharpsFromFlat_8ve(string val)
    {
        foreach (KeyValuePair<string, string> chord in sharpsNFlats_8ve)
        {
            if (val.Equals(chord.Value))
            {
                return chord.Key;
            }
        }
        return "El acorde # no existe";
    }

    private static List<List<string>> escalaNota(string notaInicial)
    {
        bool hasValue = false;
        if (notaInicial.Contains("#"))
        {
            notaInicial = listaNotasBasicas[notaInicial];
            hasValue = true;
        }

        if (list_QuintasMayores.Contains(notaInicial))
        {
            int index = list_QuintasMayores.IndexOf(notaInicial);
            List<string> scale = new List<string>() { notaInicial };
            if (notaInicial.Equals("C"))
            {
                scale.Add(list_QuintasMenores[list_QuintasMenores.Count - 1]);
                scale.Add(list_QuintasMenores[index + 1]);
                scale.Add(list_QuintasMayores[list_QuintasMenores.Count - 1]);
                scale.Add(list_QuintasMayores[index + 1]);
                scale.Add(list_QuintasMenores[index]);
                scale.Add(list_QuintasMenores[index + 2]);
            }
            else if (notaInicial.Equals("F"))
            {
                scale.Add(list_QuintasMenores[index - 1]);
                scale.Add(list_QuintasMenores[0]);
                scale.Add(list_QuintasMayores[index - 1]);
                scale.Add(list_QuintasMayores[0]);
                scale.Add(list_QuintasMenores[index]);
                scale.Add(list_QuintasMenores[1]);
            }
            else if (notaInicial.Equals("Bb"))
            {
                scale.Add(list_QuintasMenores[index - 1]);
                scale.Add(list_QuintasMenores[index + 1]);
                scale.Add(list_QuintasMayores[index - 1]);
                scale.Add(list_QuintasMayores[index]);
                scale.Add(list_QuintasMenores[index + 1]);
                scale.Add(list_QuintasMenores[0]);
            }
            else
            {
                scale.Add(list_QuintasMenores[index - 1]);
                scale.Add(list_QuintasMenores[index + 1]);
                scale.Add(list_QuintasMayores[index - 1]);
                scale.Add(list_QuintasMayores[index + 1]);
                scale.Add(list_QuintasMenores[index]);
                scale.Add(list_QuintasMenores[index + 2]);
            }

            List<List<string>> listaCoro = new List<List<string>>();

            if (hasValue)
            {
                List<string> arranged_scale = new List<string>();
                for (int i = 0; i < scale.Count; i++)
                {
                    string chord = scale[i];
                    if (chord.Contains("b"))
                    {
                        arranged_scale.Add(getSharpsFromFlat(chord));
                    }
                    else
                    {
                        arranged_scale.Add(chord);
                    }
                }

                for (int c = 0; c < arranged_scale.Count; c++)
                {
                    List<string> the_chordd = new List<string>();
                    if (c == 4) //para modificar el acorde dominante
                    {
                        the_chordd = notasCoro(arranged_scale[c], false, true);
                    }
                    else
                    {
                        the_chordd = notasCoro(arranged_scale[c]);
                    }

                    Debug.Log(listaTonalidades[c + 1] + ": " + arranged_scale[c] + " - " + string.Join(",", the_chordd));
                    listaCoro.Add(the_chordd);
                }
            }
            else
            {
                List<string> arranged_scale = new List<string>();
                for (int i = 0; i < scale.Count; i++)
                {
                    string chord = scale[i];
                    if (chord.Contains("#"))
                    {
                        string ch = listaNotasBasicas[chord];

                        arranged_scale.Add(ch);
                    }
                    else
                    {
                        arranged_scale.Add(chord);
                    }
                }

                for (int c = 0; c < arranged_scale.Count; c++)
                {

                    List<string> the_chordd = new List<string>();
                    if (c == 4)  //para modificar el acorde dominante
                    {
                        the_chordd = notasCoro(arranged_scale[c], true, true);
                    }
                    else
                    {
                        the_chordd = notasCoro(arranged_scale[c], true);
                    }

                    Debug.Log(listaTonalidades[c + 1] + ": " + arranged_scale[c] + " - " + string.Join(",", the_chordd));
                    listaCoro.Add(the_chordd);
                }
            }

            return listaCoro;
        }
        else
        {

            return null;
        }

    }

    private static List<string> notasCoro(string chord, bool flat_scale = false, bool dominant = false)
    {
        bool minor = false;
        bool flat = false;
        if (chord.Contains("m") && chord.Contains("b"))
        {
            chord = chord.Replace("m", "");
            chord = getSharpsFromFlat(chord);
            minor = true;
            flat = true;
        }
        else if (chord.Contains("b"))
        {
            chord = getSharpsFromFlat(chord);
            flat = true;
        }
        else if (chord.Contains("m"))
        {
            chord = chord.Replace("m", "");
            minor = true;
        }

        if (flat_scale == true)
        {
            flat = true;
        }

        if (llist_EscalaCromatica.Contains(chord))
        {
            int index = llist_EscalaCromatica.IndexOf(chord);
            List<string> chord_notes = new List<string>();

            //for no altered chords
            int first_note;
            int third_note;
            int fifth_note;

            if (dominant)
            { //siempre sera mayor
                first_note = 1 + index;
                third_note = 5 + index;
                fifth_note = 8 + index;


                chord_notes.Add(listEscalaCromaticaV2[first_note - 1]);
                chord_notes.Add(listEscalaCromaticaV2[third_note - 1]);
                chord_notes.Add(listEscalaCromaticaV2[fifth_note - 1]);
            }
            else if (minor)
            {
                first_note = 1 + index;
                third_note = 4 + index;
                fifth_note = 8 + index;
                chord_notes.Add(listEscalaCromaticaV2[first_note - 1]);
                chord_notes.Add(listEscalaCromaticaV2[third_note - 1]);
                chord_notes.Add(listEscalaCromaticaV2[fifth_note - 1]);
            }
            else
            {
                first_note = 1 + index;
                third_note = 5 + index;
                fifth_note = 8 + index;
                chord_notes.Add(listEscalaCromaticaV2[first_note - 1]);
                chord_notes.Add(listEscalaCromaticaV2[third_note - 1]);
                chord_notes.Add(listEscalaCromaticaV2[fifth_note - 1]);
            }


            if (flat)
            {
                List<string> arranged_chord_notes = new List<string>();
                for (int i = 0; i < chord_notes.Count; i++)
                {
                    string chordd = chord_notes[i];
                    if (chordd.Contains("#"))
                    {
                        arranged_chord_notes.Add(sharpsNFlats_8ve[chordd]);
                    }
                    else
                    {
                        arranged_chord_notes.Add(chordd);
                    }
                }
                return arranged_chord_notes;
            }
            else
            {
                return chord_notes;
            }
        }
        else
        {
            Debug.Log("La nota ingresada no existe! No se puede generar el acorde de triada.");
            return null;
        }
    }

    private static List<string> generadorProgresiones(List<List<string>> listaCoro)
    {
        List<string> tonics = new List<string>() { "1", "3", "6" };
        List<string> subdominants = new List<string>() { "2", "4" };
        List<string> dominants = new List<string>() { "5" };
        //32 compases aprox un minuto de cancion.
        List<string> progression = new List<string>();

        List<string> verse1 = generadorVersos(tonics, subdominants);
        List<string> verse2 = generadorVersos(tonics, subdominants);
        for (int i = 0; i < verse1.Count; i++)
        {
            progression.Add(verse1[i]);
        }
        for (int i = 0; i < verse2.Count; i++)
        {
            progression.Add(verse2[i]);
        }
        //Debug.Log("progression");
        //Debug.Log(string.Join(",", progression));
        return progression;
    }

    public static List<List<string>> chordsList(string note_name)
    {
        List<List<string>> listaCoro = escalaNota(note_name);
        return listaCoro;
    }

    public static List<string> progressionToUse(List<List<string>> listaCoro)
    {
        return generadorProgresiones(listaCoro);
    }

    private static List<string> generadorVersos(List<string> tonics, List<string> subdominants)
    {
        List<string> progression = new List<string>();

        int random_tonic;
        int random_subd;
        for (int i = 1; i < 5; i++)
        {
            random_tonic = Random.Range(0, 3);
            random_subd = Random.Range(0, 2);
            //primer compas siempre tendra el primer acorde de tonica
            if (i == 1)
            {
                progression.Add(tonics[0]);
                progression.Add(tonics[0]);
                progression.Add(tonics[0]);
                progression.Add(tonics[0]);

            }
            else if (4 % i == 0) // compases pares tendran tonica o subdominante
            {
                int choice = Random.Range(0, 2);
                if (choice == 0)
                {
                    //se escoge tonica
                    string ton = tonics[random_tonic];
                    if (ton == progression[progression.Count - 1])
                    {
                        List<string> tonics_without_repeated_chord = new List<string>();
                        for (int e = 0; e < tonics.Count; e++)
                        {
                            tonics_without_repeated_chord.Add(tonics[e]);
                        }
                        tonics_without_repeated_chord.Remove(ton);
                        int random_tonicc = Random.Range(0, 2); //plus 1 because the max value is not included

                        progression.Add(tonics_without_repeated_chord[random_tonicc]);
                        progression.Add(tonics_without_repeated_chord[random_tonicc]);
                        progression.Add(tonics_without_repeated_chord[random_tonicc]);
                        progression.Add(tonics_without_repeated_chord[random_tonicc]);
                    }
                    else
                    {
                        progression.Add(ton);
                        progression.Add(ton);
                        progression.Add(ton);
                        progression.Add(ton);
                    }
                }
                else
                {
                    string subd = subdominants[random_subd];
                    //si el acorde de este compas es igual al acorde del anterior
                    if (subd == progression[progression.Count - 1])
                    {
                        List<string> subdominants_withou_repeated_chord = new List<string>();
                        for (int e = 0; e < subdominants.Count; e++)
                        {
                            subdominants_withou_repeated_chord.Add(tonics[e]);
                        }
                        subdominants_withou_repeated_chord.Remove(subd);

                        progression.Add(subdominants_withou_repeated_chord[0]);
                        progression.Add(subdominants_withou_repeated_chord[0]);
                        progression.Add(subdominants_withou_repeated_chord[0]);
                        progression.Add(subdominants_withou_repeated_chord[0]);
                    }
                    else
                    {
                        progression.Add(subd);
                        progression.Add(subd);
                        progression.Add(subd);
                        progression.Add(subd);
                    }
                }
            }
            else
            {
                //primer acorde de tonica
                progression.Add(tonics[0]); //"1"
                progression.Add(tonics[0]); //"1"
                progression.Add(tonics[0]); //"1"
                progression.Add(tonics[0]); //"1"
            }
        }
        return progression;
    }


}
