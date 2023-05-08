# BLEU-Challenge-ParserLog

The project was written in C# using a console application template.

This project builds an executable capable of reading a log file from the Tibia server log, created during game sessions.

The objective is to read the file, organize the information and format the data output according to the specifications of this challenge.

# How to run this application:


# Project Design:

The project has several folders where classes were grouped by affinity.

Yes. There really are many classes, but the idea is to create classes with single responsibility based on good design practices.

## Core:
Responsable to import files, enviroment settings, sessions of logs and define what data needs to show in the output.

## Format:
Responsable to format the output data, extracting informations of views created during the parser process.

## Group:
Responsable to grouping data of views that need to be details.

## List:
Responsable to manager classes that need to be detailed.

## Log:
Responsable to define the identity of each record log and extract the correct data parameters.

## Model:
Responsable to define structure of views and reuse informations.

## Regex:
Responsable to register and apply the patterns and parameters that will be extracted during the parser process.

## View:
Responsable to organize views and grouping data for types of logs.

## Util:
Responsable to apply generic function and give the code more clean as possible.

# Unit Testing

This project has 5 unitTesting classes created to validate different levels of ParserLog functionality. I was applied the Xunit library.

The first test level was created to test log pattern recognition and grouping different data.

The second test level envolving to read fake files and verify it is code grouping correctly data in a unique kind of log.

The third level envolving to use real files and apply filters to validate and separeted in different groups of data.

# Views of the FileLog

It is possible to define which views will be shown in the data output:

public StartApp()
{
    show.PlayerStatistics = true;
    show.CreatureStatistics = true;
    show.LootedItems = true;
    show.CreatureSpotlight = true; // Extra Challenge
}

## Player Statistics:

============================================================
                     Player Statistics                      
------------------------------------------------------------
  Experience                        28,462 points     129#
  HealedPower                        8,048 points      27#
  LostPower                          7,683 points     353#
   -unknown                          2,137 points     203#
   -byCreature                       5,546 points     150#
     -Black Knight                     449 points       4#
     -bonelord                         234 points       8#
     -cyclops                          101 points       6#
     -cyclops smith                     29 points       1#
     -dragon                         2,427 points      44#
     -dragon lord                    1,770 points      34#
     -dwarf soldier                     17 points       3#
     -ghoul                              2 points       1#
     -scorpion                         470 points      45#
     -wyvern                            47 points       4#
------------------------------------------------------------

## Creature Statistics:

============================================================
                    Creature Statistics                     
------------------------------------------------------------
   -HealedPower                        405 points       6#
     -dragon                           171 points       3#
     -dragon lord                      234 points       3#
   -LostPower                       39,407 points     205#
     -bat                               60 points       2#
     -Black Knight                   1,800 points       7#
     -bonelord                       1,820 points       7#
     -bug                               87 points       3#
     -cyclops                        2,080 points       8#
     -cyclops smith                    435 points       2#
     -deer                              50 points       2#
     -dragon                        21,821 points      68#
     -dragon hatchling                 760 points       2#
     -dragon lord                    4,034 points      15#
     -dwarf                            540 points       6#
     -dwarf soldier                    540 points       4#
     -ghoul                            100 points       1#
     -rat                               20 points       1#
     -scorpion                       2,385 points      53#
     -skeleton                         300 points       6#
     -snake                             30 points       2#
     -spider                            60 points       3#
     -wolf                             100 points       4#
     -wyvern                         2,385 points       9#
------------------------------------------------------------

## Looted Items:

============================================================
                        Looted Items                        
------------------------------------------------------------
  LootedByCreature                   1,258 items      129#
     -bolts                              7 items        2#
     -bone                               1 items        1#
     -burst arrows                       2 items        1#
     -copper shield                      1 items        1#
     -crossbow                           2 items        2#
     -cyclops toe                        1 items        1#
     -cyclops trophy                     1 items        1#
     -dragon ham                        26 items       19#
     -dragon's tail                      3 items        3#
     -gold coins                     1,177 items       52#
     -green dragon leather               1 items        1#
     -ham                                1 items        1#
     -hatchet                            2 items        2#
     -leather legs                       1 items        1#
     -letter                             1 items        1#
     -longsword                          2 items        2#
     -meat                               6 items        4#
     -pick                               1 items        1#
     -plate legs                         3 items        3#
     -royal spear                        1 items        1#
     -scorpion tail                      3 items        3#
     -small diamond                      2 items        2#
     -soldier helmet                     2 items        2#
     -spellbook                          1 items        1#
     -steel helmet                       2 items        2#
     -steel shield                       4 items        4#
     -strong health potion               1 items        1#
     -two handed sword                   1 items        1#
     -white mushrooms                    2 items        1#
------------------------------------------------------------

## Creature Spotlight:

============================================================
            Creature Spotlight: cyclop*, dragon*            
------------------------------------------------------------
  Creature Name      HealedPower    LostPower DamagePlayer
  cyclops                     0        2,080          101
  cyclops smith               0          435           29
  dragon                    171       21,821        2,427
  dragon hatchling            0          760            0
  dragon lord               234        4,034        1,770
------------------------------------------------------------

## Extra Challeng: Black Knight creature

In the debug mode it is possible to put a wildcard *Knight*

#if DEBUG
        app.fileName = "Session-Full.txt"; 
        app.creatureRules = "*Knight*";
#else
        app.fileName = arg[0];
        app.creatureRules = (args.Length >= 2) ? args[1] : "";
#endif

The result will be this ...

============================================================
                Creature Spotlight: *Knight*                
------------------------------------------------------------
  Creature Name      HealedPower    LostPower DamagePlayer
  Black Knight                0        1,800          449
------------------------------------------------------------
           Statistics based by file log extracted           
============================================================