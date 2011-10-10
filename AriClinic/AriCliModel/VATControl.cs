using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AriCliModel
{
    public static class VATControl
    {
        public static bool ValidateNif(ref string nif)
        {

            //*******************************************************************
            // Nombre:     ValidateNif
            //             por Enrique Martínez Montejo
            //
            // Finalidad:  Validar el NIF/NIE pasado a la función.
            //
            // Entradas:
            //     NIF:    String. El NIF/NIE que se desea verificar. El número
            //             será devuelto formateado y con el NIF/NIE correcto.
            // Resultados:
            // Boolean:    True/False
            //
            //*******************************************************************

            string nifTemp = nif.Trim().ToUpper();

            if ((nifTemp.Length > 9))
                return false;

            // Guardamos el dígito de control.
            char dcTemp = nifTemp[nif.Length - 1];

            // Compruebo si el dígito de control es un número.
            if ((char.IsDigit(dcTemp)))
                return false;

            // Nos quedamos con los caracteres, sin el dígito de control.
            nifTemp = nifTemp.Substring(0, nif.Length - 1);

            if ((nifTemp.Length < 8))
            {
                string paddingChar = new string('0', 8 - nifTemp.Length);
                nifTemp = nifTemp.Insert(nifTemp.Length, paddingChar);
            }

            // Obtengo el dígito de control correspondiente, utilizando
            // para ello una llamada a la función GetDcCif.
            //
            char dc = GetDcNif(nif);

            if ((!(dc == char.Parse(" "))))
            {
                nif = nifTemp + dc;
            }

            return (dc == dcTemp);

        }
        public static char GetDcNif(string nif)
        {

            //*******************************************************************
            // Nombre:     GetDcNif
            //             por Enrique Martínez Montejo
            //
            // Finalidad:  Devuelve la letra correspondiente al NIF o al NIE
            //             (Número de Identificación de Extranjero)
            //
            // Entradas:
            //     NIF:    String. La cadena del NIF cuya letra final se desea
            //             obtener.
            //
            // Resultados:
            //     String: La letra del NIF/NIE.
            //
            //*******************************************************************

            // Pasamos el NIF a mayúscula a la vez que eliminamos los
            // espacios en blanco al comienzo y al final de la cadena.
            //
            nif = nif.Trim().ToUpper();

            // El NIF está formado de uno a nueve números seguido
            // de una letra.
            //
            // El NIF de otros colectivos de personas físicas, está
            // formato por una letra (K, L, M), seguido de 7 números
            // y de una letra final.
            //
            // El NIE está formado de una letra inicial (X, Y, Z),
            // seguido de 7 números y de una letra final.
            // 
            // En el patrón de la expresión regular, defino cuatro grupos en el
            // siguiente orden:
            //
            // 1º) 1 a 8 dígitos.
            // 2º) 1 a 8 dígitos + 1 letra.
            // 3º) 1 letra + 1 a 7 dígitos 
            // 4º) 1 letra + 1 a 7 dígitos + 1 letra.
            //
            try
            {
                Regex re = new Regex("(^\\d{1,8}$)|(^\\d{1,8}[A-Z]$)|(^[K-MX-Z]\\d{1,7}$)|(^[K-MX-Z]\\d{1,7}[A-Z]$)", RegexOptions.IgnoreCase);

                if ((!(re.IsMatch(nif))))
                    return char.Parse(" ");

                // Nos quedamos únicamente con los números del NIF, y
                // los formateamos con ceros a la izquierda si su
                // longitud es inferior a siete caracteres.
                //
                re = new Regex("(\\d{1,8})");

                string numeros = re.Match(nif).Value.PadLeft(7, '0');

                // Primer carácter del NIF.
                //
                char firstChar = nif[0];

                // Si procede, reemplazamos la letra del NIE
                // por el peso que le corresponde.
                //
                if ((firstChar == 'X'))
                {
                    numeros = "0" + numeros;

                }
                else if ((firstChar == 'Y'))
                {
                    numeros = "1" + numeros;

                }
                else if ((firstChar == 'Z'))
                {
                    numeros = "2" + numeros;

                }

                // Tabla del NIF
                //
                //  0T  1R  2W  3A  4G  5M  6Y  7F  8P  9D
                // 10X 11B 12N 13J 14Z 15S 16Q 17V 18H 19L
                // 20C 21K 22E 23T
                //
                // Procedo a calcular el NIF/NIE
                //
                int dni = Convert.ToInt32(numeros);

                // La operación consiste en calcular el resto de dividir el DNI
                // entre 23 (sin decimales). Dicho resto (que estará entre 0 y 22),
                // se busca en la tabla y nos da la letra del NIF.
                //
                // Obtenemos el resto de la división.
                //
                int r = dni % 23;

                // Obtenemos el dígito de control del NIF
                //
                char dc = Convert.ToChar("TRWAGMYFPDXBNJZSQVHLCKE".Substring(r, 1));

                return dc;

            }
            catch
            {
                // Cualquier excepción producida, devolverá el valor Nothing.
                //
                return char.Parse(" ");

            }

        }
        public static bool ValidateCif(ref string nif)
        {

            //*******************************************************************
            // Nombre:     ValidateCif
            //             por Enrique Martínez Montejo
            //
            // Finalidad:  Validar el NIF pasado a la función.
            //
            // Entradas:
            //     nif:    String. El NIF que se desea verificar. El número
            //             será devuelto formateado con el NIF correcto.
            // Resultados:
            //     Boolean: True/False
            //
            //*******************************************************************

            string nifTemp = nif.Trim().ToUpper();

            if ((nifTemp.Length < 9))
                return false;

            // Guardamos el noveno carácter.
            char dcTemp = nifTemp[8];

            // Nos quedamos con los primeros ocho caracteres.
            nifTemp = nifTemp.Substring(0, 8);

            // Obtengo el dígito de control correspondiente, utilizando
            // para ello una llamada a la función GetDcCif
            //
            char dc = GetDcCif(nif);

            if ((!(dc.Equals(' '))))
            {
                nif = nifTemp + dc;
            }

            return (dc == dcTemp);

        }
        public static char GetDcCif(string nif)
        {

            //*******************************************************************
            // Nombre:     GetDcCif
            //             por Enrique Martínez Montejo
            //
            // Finalidad:  Obtener el Dígito de Control de un NIF correspondiente
            //             a personas jurídicas y otras entidades con o sin 
            //             personalidad jurídica.
            //
            // Entradas:
            //     nif:    String. El NIF cuyo dígito de control se desea obtener.
            //
            // Resultados:
            //     String: La letra o el número correspondiente al NIF.
            //
            //*******************************************************************

            // Pasamos el NIF a mayúscula a la vez que eliminamos todos los
            // carácteres que no sean números o letras. Note que no incluyo
            // la letra I, porque si bien no puede aparecer como carácter
            // inicial de un NIF, sí puede ser un dígito de control válido,
            // lo que no sucede con las letras O y T.
            //
            Regex re = new Regex("([^A-W0-9]|[OT]|[^\\w])", RegexOptions.IgnoreCase);

            nif = re.Replace(nif, string.Empty).ToUpper();

            // Para calcular el CIF, se debe de haber pasado un máximo
            // de nueve caracteres a la función: una letra válida (que
            // necesariamente deberá de estar comprendida en el intervalo
            // ABCDEFGHJKLMNPQRSUVW), siete números, y el dígito de control,
            // que puede ser un número o una letra, dependiendo de la entidad
            // a la que pertenezca el NIF.
            //
            // En el patrón de la expresión regular, defino dos grupos en el
            // siguiente orden:
            // 1º) 1 letra + 7 u 8 dígitos.
            // 2º) 1 letra + 7 dígitos + 1 letra.
            //
            // Note que en el siguiente patrón, no incluyo la letra I como
            // carácter de inicio válido del NIF.
            //
            re = new Regex("(^[A-HJ-W]\\d{7,8}$)|(^[A-HJ-W]\\d{7}[A-Z]$)");

            if ((!(re.IsMatch(nif))))
                return char.Parse(" ");

            try
            {
                // Guardo el último carácter pasado, siempre que
                // el NIF disponga de nueve caracteres.
                //
                char lastChar = char.Parse(" ");
                if ((nif.Length == 9))
                    lastChar = nif[8];

                Int32 sumaPar = default(Int32);
                Int32 sumaImpar = default(Int32);

                // A continuación, la cadena debe tener 7 dígitos.
                //
                string digits = nif.Substring(1, 7);


                for (Int32 n = 0; n <= digits.Length - 1; n += 2)
                {
                    if ((n < 6))
                    {
                        // Sumo las cifras pares del número que se corresponderá
                        // con los caracteres 1, 3 y 5 de la variable «digits».
                        //
                        sumaImpar += Convert.ToInt32(Convert.ToString(digits[n + 1]));
                    }

                    // Multiplico por dos cada cifra impar (caracteres 0, 2, 4 y 6).
                    //
                    Int32 dobleImpar = 2 * Convert.ToInt32(Convert.ToString(digits[n]));

                    // Acumulo la suma del doble de números impares.
                    //
                    sumaPar += (dobleImpar % 10) + (dobleImpar / 10);

                }

                // Sumo las cifras pares e impares.
                //
                Int32 sumaTotal = sumaPar + sumaImpar;

                // Me quedo con la cifra de las unidades y se la resto a 10, siempre
                // y cuando la cifra de las unidades sea distinta de cero
                //
                sumaTotal = (10 - (sumaTotal % 10)) % 10;

                char[] characters = {
			'J',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I'
		};

                char dc = characters[sumaTotal];

                // Devuelvo el Dígito de Control dependiendo del primer carácter
                // del NIF pasado a la función.
                //
                char firstChar = nif[0];

                switch (firstChar)
                {
                    case 'N':
                    case 'P':
                    case 'Q':
                    case 'R':
                    case 'S':
                    case 'W':
                    case 'K':
                    case 'L':
                    case 'M':

                        // NIF de entidades cuyo dígito de control se corresponde
                        // con una letra. Se incluyen las letras K, L y M porque
                        // el cálculo del dígito de control es el mismo que para
                        // el CIF.
                        //
                        // Al estar los índices de los arrays en base cero, el primer
                        // elemento del array se corresponderá con la unidad del número
                        // 10, es decir, el número cero.
                        //

                        return characters[sumaTotal];
                    case 'C':
                        if (((lastChar == Convert.ToChar(sumaTotal)) || (lastChar == dc)))
                        {
                            // Devuelvo el dígito de control pasado, que
                            // puede ser un número o una letra.
                            return lastChar;

                        }
                        else
                        {
                            // Devuelvo la letra correspondiente al cálculo
                            // del dígito de control del NIF.
                            return dc;

                        }

                       
                    default:
                        // NIF de las restantes entidades, cuyo dígito de control es un número.
                        //

                        return Convert.ToChar(Convert.ToString(sumaTotal));
                }

            }
            catch
            {
                // Cualquier excepción producida, devolverá Nothing. 
                //
                return char.Parse(" ");

            }

        }

    }
}
