using System;

/*
Exceeding Requirements
- Choose scriptures at random to present to the user: I created a function called
GetRandomScripture() that randomly selects a scripture given an array of scriptures.
Function returns a Scripture object.
*/

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        bool validInput = false;
        int numberOfWordsToHide = 3;

        Scripture scripture = GetRandomScripture();
        Console.WriteLine(scripture.GetDisplayText());

        while (!quit)
        {
            while (!validInput)
            {
                Console.Write("Press enter to continue or type 'quit' to finish: ");
                string userInput = Console.ReadLine();
                quit = userInput == "quit";

                if (string.IsNullOrEmpty(userInput) || quit)
                {
                    if (scripture.IsCompletelyHidden())
                    {
                        quit = true;
                    }
                    validInput = true;
                }
            }

            validInput = false;

            if (!quit)
            {
                scripture.HideRandomWords(numberOfWordsToHide);
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
            }
        }
    }

    static Scripture GetRandomScripture()
    {
        string[,] scriptureMasteryPassages = {
            {"Moses","1","19","0","For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."},
            {"Matthew","11","28","30","Come unto me, all ye that labour and are heavy laden, and I will give you rest. Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls. For my yoke is easy, and my burden is light."},
            {"2 Nephi","2","25","0","Adam fell that men might be; and men are, that they might have joy"},
            {"2 Nephi","2","27","0","Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself."},
            {"D&C","6","36","0","Look unto me in every thought; doubt not, fear not."},
            {"D&C","8","2","3","Yea, behold, I will tell you in your mind and in your heart, by the Holy Ghost, which shall come upon you and which shall dwell in your heart. Now, behold, this is the spirit of revelation; behold, this is the spirit by which Moses brought the children of Israel through the Red Sea on dry ground."},
            {"Genesis","2","24","0","Therefore shall a man leave his father and his mother, and shall cleave unto his wife: and they shall be one flesh."},
            {"John","3","5","0","Jesus answered, Verily, verily, I say unto thee, Except a man be born of water and of the Spirit, he cannot enter into the kingdom of God."},
            {"D&C","13","1","0","Upon you my fellow servants, in the name of Messiah I confer the Priesthood of Aaron, which holds the keys of the ministering of angels, and of the gospel of repentance, and of baptism by immersion for the remission of sins; and this shall never be taken again from the earth, until the sons of Levi do offer again an offering unto the Lord in righteousness"}
        };

        Random randomGenerator = new Random();
        int idx = randomGenerator.Next(0, scriptureMasteryPassages.GetLength(1));

        string book = scriptureMasteryPassages[idx, 0];
        int chapter = Convert.ToInt32(scriptureMasteryPassages[idx, 1]);
        int verse = Convert.ToInt32(scriptureMasteryPassages[idx, 2]);
        int endVerse = Convert.ToInt32(scriptureMasteryPassages[idx, 3]);
        string text = scriptureMasteryPassages[idx, 4];

        Reference reference = new Reference(book, chapter, verse, endVerse);
        return new Scripture(reference, text);
    }
}