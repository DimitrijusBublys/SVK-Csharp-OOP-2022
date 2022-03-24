using System;
using Microsoft.VisualBasic.FileIO;

namespace Files
{
    class CreatingFile
    {
        public string directoryName = "Placeholder";
        public int fileNum; 

        public CreatingFile(string name, int times)
        {
            directoryName = name;
            fileNum = times;
        }

        public void createDirectory()
        {
            if (FileSystem.DirectoryExists(directoryName))
            {
                Console.WriteLine("Directory named " + directoryName  + " already exists.");
            }
            else
            {
                FileSystem.CreateDirectory(directoryName);
                Console.WriteLine("Directory named " + directoryName + " was created.");
            }
        }
        public void generateFiles()
        {
            int num = 1; // Failo pavadinimo skaičius
            directoryName += "/";
            while (fileNum > 0)
            {
                string currDate = DateTime.Now.ToString("yyyy/MM/dd"); // Dabartinė data LT formatu
                string tempName = "a" + num + ".txt"; // Failo pavadinimas
                string tempNameLocated = "a" + num + "_" + currDate + ".txt"; // Jeigu yra failas tokiu pav, kaip tempName

                // Atsitiktinis skaičius (0 ir 1)

                Random rndNum = new Random();
                int random = rndNum.Next(0, 2); 
                string randomNumber = random.ToString();

                if (File.Exists(directoryName + tempName)) // Jeigu egzistuoja failas su tempName pavadinimu
                {

                    if (File.Exists(directoryName + tempNameLocated)) // Jeigu egzistuoja failas, tačiau jau buvo pakeistas šio pavadinimas
                    {
                        File.Delete(directoryName + tempNameLocated);
                    }
                    FileSystem.RenameFile(directoryName + tempName, tempNameLocated); // Failo pervadinimas

                }
                else  // Jeigu failas neegzistuoja
                {
                    FileSystem.WriteAllText(directoryName + tempName, randomNumber, true); // Naudojama funkcija failui ir tekstui iš karto sukurti. (File.Create neveikė, kadangi ši funkcija po failo sukurimo neužsidaro.)
                }
                num++; 
                fileNum--;
            }
        }

        public void report(string folderName, string textName)
        {
            //bool isZero = false;
            string anotherDir = folderName;
            string fileName = textName + ".txt";
            int isZero = 0;
            int isOne = 0;

            directoryName += "/";


            if (FileSystem.DirectoryExists(directoryName + "/" + anotherDir)) // Jeigu jau yra folderis tokiu pat pavadinimu, šis ištrinamas.
            {
                Console.WriteLine("Report directory named " + anotherDir + " already exists but was deleted with all of its contents.");
                File.Delete(directoryName + anotherDir + fileName);
                Directory.Delete(directoryName + anotherDir, true);
            }

            FileSystem.CreateDirectory(directoryName + anotherDir);
            Console.WriteLine("Report directory named " + anotherDir + " was created.");

            foreach (string a in FileSystem.GetFiles(directoryName))
            {

                string current = File.ReadAllText(a);

                if(current == "0")
                {
                    isZero++;

                }
                else
                {
                    isOne++;
                }
            }

            // Kuriamas ataskaitos teksto failas, į kurį įrašoma informacija.
            FileSystem.WriteAllText(directoryName + anotherDir + "/" + fileName,
            "The program has found " + isZero + " text files that contain the number 0, as well as " + isOne + " files that contain the number 1.", true); 

        }

        public void delete()
        {
            directoryName += "/";

            foreach (string a in FileSystem.GetFiles(directoryName))
            {

                string current = File.ReadAllText(a);

                if (current == "0")
                {
                    File.Delete(a);
                }
            }
        }

    }
}
