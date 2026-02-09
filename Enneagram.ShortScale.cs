/*
 *  DISCLAIMER: This project is a personal learning exercise.
 *  The assessment items are generated for demonstration purposes.
 *  For important disclaimers, licenses, and source attributions,
 *  please refer to the README.md file in the root repository.
 *  
 *  This code is licensed under the MIT License.
 */
namespace Enneagram.ShortScale;

/// <summary>
/// Core module for RHETI-style Enneagram assessment (short version), based on Riso-Hudson 
/// Enneagram theory. It focuses on core motivations/fears dimension and is adapted for the
/// single-file execution mode in .NET 10 SDK.
/// </summary>
file static class Assessment
{
    /// <summary>
    /// Enneagram core type definitions
    /// </summary>
    private enum EnneagramType
    {
        Type1 = 1, // Perfectionist: Pursues correctness, fears mistakes
        Type2 = 2, // Helper: Pursues being needed, fears not being loved
        Type3 = 3, // Achiever: Pursues success, fears failure/being worthless
        Type4 = 4, // Individualist: Pursues uniqueness, fears mediocrity/being forgotten
        Type5 = 5, // Investigator: Pursues knowledge, fears ignorance/being depleted
        Type6 = 6, // Loyalist: Pursues security, fears uncertainty/betrayal
        Type7 = 7, // Enthusiast: Pursues pleasure, fears pain/limitations
        Type8 = 8, // Challenger: Pursues control, fears vulnerability/being harmed
        Type9 = 9  // Peacemaker: Pursues harmony, fears conflict/separation
    }

    // Stores scores for each type
    private static readonly Dictionary<EnneagramType, int> _typeScores = [];

    // RHETI-style assessment question bank (core motivation oriented, 8 questions per type, 72 total questions)
    private static readonly List<Question> _questions =
    [
        // Type 1 questions
        new(EnneagramType.Type1, "I often feel dissatisfied when things aren't done the 'right' way"),
        new(EnneagramType.Type1, "I find it hard to accept obvious mistakes in myself or others"),
        new(EnneagramType.Type1, "I unconsciously set behavioral standards for myself and others and expect compliance"),
        new(EnneagramType.Type1, "I easily feel angry about 'irresponsible' or 'perfunctory' behavior"),
        new(EnneagramType.Type1, "I often reflect on whether I've made the 'right' choices"),
        new(EnneagramType.Type1, "I have little tolerance for chaos and disorder"),
        new(EnneagramType.Type1, "I tend to judge things using 'should/shouldn't'"),
        new(EnneagramType.Type1, "I fear my actions might violate morals or principles"),
        
        // Type 2 questions
        new(EnneagramType.Type2, "I prioritize others' needs, even neglecting my own"),
        new(EnneagramType.Type2, "I fear being seen as 'selfish' or 'unhelpful' by others"),
        new(EnneagramType.Type2, "I gain recognition and affection by helping others"),
        new(EnneagramType.Type2, "I find it hard to directly express my true needs"),
        new(EnneagramType.Type2, "I remember others' preferences and actively satisfy them"),
        new(EnneagramType.Type2, "I fear being 'useless' to others"),
        new(EnneagramType.Type2, "I easily fall into a pattern of 'giving-expecting something in return'"),
        new(EnneagramType.Type2, "I unconsciously cater to others' emotions and preferences"),
        
        // Type 3 questions
        new(EnneagramType.Type3, "I'm very concerned about my 'successful' image in others' eyes"),
        new(EnneagramType.Type3, "I fear my efforts won't be recognized or rewarded"),
        new(EnneagramType.Type3, "I adjust my behavior to achieve goals"),
        new(EnneagramType.Type3, "I find it hard to accept 'failure' results"),
        new(EnneagramType.Type3, "I'm always planning the next achievement goal"),
        new(EnneagramType.Type3, "I fear being 'accomplished nothing' or 'valueless'"),
        new(EnneagramType.Type3, "I tie my personal worth to achievements"),
        new(EnneagramType.Type3, "I deliberately showcase my strengths in social situations"),
        
        // Type 4 questions
        new(EnneagramType.Type4, "I always feel different from others and crave a unique sense of existence"),
        new(EnneagramType.Type4, "I fear my life will be 'mediocre'"),
        new(EnneagramType.Type4, "I'm very sensitive to emotions and easily fall into deep thinking"),
        new(EnneagramType.Type4, "I often feel that my 'true self' isn't understood"),
        new(EnneagramType.Type4, "I'm attracted to artistic or unique things"),
        new(EnneagramType.Type4, "I fear being forgotten or becoming 'like everyone else'"),
        new(EnneagramType.Type4, "I repeatedly reflect on the beauty or regrets of the past"),
        new(EnneagramType.Type4, "I pursue deep emotional connections rather than superficial socializing"),
        
        // Type 5 questions
        new(EnneagramType.Type5, "I need a lot of alone time to organize my thoughts and recharge"),
        new(EnneagramType.Type5, "I fear appearing ignorant due to insufficient knowledge"),
        new(EnneagramType.Type5, "I actively learn various knowledge to deal with unknown situations"),
        new(EnneagramType.Type5, "I tend to do thorough research and analysis before acting"),
        new(EnneagramType.Type5, "I fear my personal space being excessively occupied"),
        new(EnneagramType.Type5, "I deliberately reserve energy to avoid unnecessary consumption"),
        new(EnneagramType.Type5, "I have a strong desire to explore abstract concepts and theories"),
        new(EnneagramType.Type5, "I find it hard to accept 'making decisions based on feelings'"),
        
        // Type 6 questions
        new(EnneagramType.Type6, "I anticipate various risks in advance and prepare responses"),
        new(EnneagramType.Type6, "I fear uncertain futures and sudden changes"),
        new(EnneagramType.Type6, "I rely on trusted people or rules to gain a sense of security"),
        new(EnneagramType.Type6, "I easily doubt others' intentions"),
        new(EnneagramType.Type6, "I fear being betrayed or abandoned"),
        new(EnneagramType.Type6, "I repeatedly confirm the feasibility and safety of plans"),
        new(EnneagramType.Type6, "I both rely on and remain vigilant towards authority"),
        new(EnneagramType.Type6, "Under pressure, I become anxious and seek definite answers"),
        
        // Type 7 questions
        new(EnneagramType.Type7, "I'm always looking for new pleasures and experiences, hating monotony"),
        new(EnneagramType.Type7, "I fear falling into painful or boring states"),
        new(EnneagramType.Type7, "I plan multiple interesting things at once, unwilling to miss any"),
        new(EnneagramType.Type7, "I tend to avoid negative emotions by turning to positive things"),
        new(EnneagramType.Type7, "I fear losing freedom or the right to choose"),
        new(EnneagramType.Type7, "I look forward to the future and enjoy imagining various possibilities"),
        new(EnneagramType.Type7, "I find it hard to focus on a boring task for a long time"),
        new(EnneagramType.Type7, "I use an optimistic attitude to mask inner anxiety"),
        
        // Type 8 questions
        new(EnneagramType.Type8, "I like to be in control and don't want to be dominated by others"),
        new(EnneagramType.Type8, "I fear becoming vulnerable and being harmed by others"),
        new(EnneagramType.Type8, "I actively protect people or things I care about"),
        new(EnneagramType.Type8, "I find it hard to show weakness, even when hurt inside"),
        new(EnneagramType.Type8, "I fear injustice and will fight for rights for myself and others"),
        new(EnneagramType.Type8, "I have a strong resistance to being 'controlled'"),
        new(EnneagramType.Type8, "I speak directly and don't like to beat around the bush"),
        new(EnneagramType.Type8, "I use a strong attitude to mask inner unease"),
        
        // Type 9 questions
        new(EnneagramType.Type9, "I try to avoid conflict and hope to maintain harmonious relationships"),
        new(EnneagramType.Type9, "I fear disagreements with others leading to separation"),
        new(EnneagramType.Type9, "I easily ignore my own needs and cater to others' expectations"),
        new(EnneagramType.Type9, "I like stable life and hate dramatic changes"),
        new(EnneagramType.Type9, "I procrastinate making decisions to avoid conflicts from choices"),
        new(EnneagramType.Type9, "I fear my opinions will cause dissatisfaction in others"),
        new(EnneagramType.Type9, "I'm good at listening and reconciling others' conflicts"),
        new(EnneagramType.Type9, "I escape pressure by immersing myself in familiar things")
    ];

    /// <summary>
    /// Initializes all type scores to 0.
    /// </summary>
    static Assessment()
    {
        foreach (EnneagramType type in Enum.GetValues<EnneagramType>())
        {
            _typeScores[type] = 0;
        }
    }

    /// <summary>
    /// Starts the assessment process
    /// </summary>
    public static void StartAssessment()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===== RHETI-STYLE ENNEAGRAM ASSESSMENT =====");
        Console.WriteLine("Instructions: Rate how well each statement fits you, based on your true feelings.");
        Console.WriteLine("(1 = Not at all, 2 = Slightly, 3 = Moderately, 4 = Quite well, 5 = Perfectly)");
        Console.WriteLine("--------------------------------------------\n");
        Console.ResetColor();

        // Randomly shuffle questions (avoid bias from type clustering)
        var shuffledQuestions = _questions.OrderBy(q => Guid.NewGuid()).ToList();

        // Answer questions one by one
        for (int i = 0; i < shuffledQuestions.Count; i++)
        {
            var question = shuffledQuestions[i];
            int score = 0;

            // Loop to get valid rating
            while (score < 1 || score > 5)
            {
                Console.WriteLine($"Question {i + 1}: {question.QuestionText}.");
                Console.Write("Please enter your rating (1-5): ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (!int.TryParse(input, out score) || score < 1 || score > 5)
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 5.\n");
                }
            }

            // Accumulate score for the corresponding type
            _typeScores[question.BelongingType] += score;
            Console.WriteLine();
        }

        // Generate assessment report
        GenerateReport();
    }

    /// <summary>
    /// Generate assessment report (core type + wing type + score distribution)
    /// </summary>
    private static void GenerateReport()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("* SCORE DISTRIBUTION BY TYPE *");
        // Sort by score descending
        var sortedScores = from kv in _typeScores
                           orderby kv.Value descending
                           select kv;

        foreach (var item in sortedScores)
        {
            string typeName = ((int)item.Key).GetTypeNameEN();
            Console.WriteLine($"   {item.Key} ({typeName}): {item.Value} points");
        }

        // Determine core type (highest score)
        var coreType = (int)sortedScores.First().Key;
        Console.WriteLine($"\n[CORE TYPE] Type {coreType} ({coreType.GetTypeNameEN()})");
        Console.WriteLine($"   Core motivation: {coreType.GetCoreMotivation()}");
        Console.WriteLine($"   Core fear: {coreType.GetCoreFear()}");

        // Derive wing type (higher score among adjacent types to core type)
        var wingType = GetWingType(coreType);
        if (wingType != 0)
        {
            Console.WriteLine($"\n[WING TYPE] Type {wingType} ({wingType.GetTypeNameEN()})");
            Console.WriteLine($"   Note: Wing types influence the expression of core types, making personality more complex");
        }
        Console.ResetColor();

        Console.WriteLine("\n--------------------------------------------");
        Console.WriteLine("Remember: This is a simulated RHETI-style assessment for self-exploration reference only, not an official certified assessment.");
    }

    /// <summary>
    /// Assessment question entity record
    /// </summary>
    private record Question(EnneagramType BelongingType, string QuestionText);

    /// <summary>
    /// Program entry point
    /// </summary>
    internal static void Main()
    {
        StartAssessment();
        Console.WriteLine("\nAssessment completed. Press any key to exit...");
        Console.ReadKey();
    }

    // Extension methods for Enneagram type numbers
    extension(int typeNumber)
    {
        public string GetTypeNameEN() => typeNumber switch
        {
            1 => "Perfectionist/Reformer",
            2 => "Helper/Giver",
            3 => "Achiever/Performer",
            4 => "Individualist/Romantic",
            5 => "Investigator/Observer",
            6 => "Loyalist/Skeptic",
            7 => "Enthusiast/Epicure",
            8 => "Challenger/Protector",
            9 => "Peacemaker/Mediator",
            _ => ""
        };

        public string GetCoreMotivation() => typeNumber switch
        {
            1 => "Pursues correctness, justice, and perfection; wants to be moral and principled",
            2 => "Pursues being loved and needed; wants to be valuable and popular",
            3 => "Pursues success and recognition; wants to be capable and worthy of appreciation",
            4 => "Pursues uniqueness and authenticity; wants to be meaningful and understood",
            5 => "Pursues knowledge and autonomy; wants to be capable and not drained of energy",
            6 => "Pursues security and trust; wants to be protected and have support",
            7 => "Pursues happiness and freedom; wants to be fulfilled and unrestricted",
            8 => "Pursues control and autonomy; wants to be strong and not harmed",
            9 => "Pursues harmony and peace; wants to be accepted and not separated",
            _ => ""
        };

        public string GetCoreFear() => typeNumber switch
        {
            1 => "Fears doing wrong, being immoral, becoming a bad person",
            2 => "Fears not being loved, not being needed, becoming a selfish person",
            3 => "Fears failure, worthlessness, being ignored by others",
            4 => "Fears mediocrity, being forgotten, losing self-uniqueness",
            5 => "Fears ignorance, helplessness, being drained of energy by others",
            6 => "Fears uncertainty, betrayal, falling into danger",
            7 => "Fears pain, limitations, losing freedom of choice",
            8 => "Fears vulnerability, being controlled, being treated unfairly",
            9 => "Fears conflict, separation, losing one's sense of existence",
            _ => ""
        };

        private int GetWingType()
        {
            // Enneagram wing rules:
            // 1(9/2), 2(1/3), 3(2/4), 4(3/5), 5(4/6), 6(5/7), 7(6/8), 8(7/9), 9(8/1)
            int wing1 = 0, wing2 = 0;
            switch (typeNumber)  // Map core type to wing types
            {
                case 1: wing1 = 9; wing2 = 2; break;
                case 2: wing1 = 1; wing2 = 3; break;
                case 3: wing1 = 2; wing2 = 4; break;
                case 4: wing1 = 3; wing2 = 5; break;
                case 5: wing1 = 4; wing2 = 6; break;
                case 6: wing1 = 5; wing2 = 7; break;
                case 7: wing1 = 6; wing2 = 8; break;
                case 8: wing1 = 7; wing2 = 9; break;
                case 9: wing1 = 8; wing2 = 1; break;
            }

            // Get scores for both adjacent types
            int score1 = _typeScores[(EnneagramType)wing1];
            int score2 = _typeScores[(EnneagramType)wing2];

            // No obvious wing if scores are equal
            if (score1 == score2) return 0;

            // Return the wing type with higher score
            return score1 > score2 ? wing1 : wing2;
        }
    }
}