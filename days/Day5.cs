﻿using System;

namespace advent
{
    public class Day5 : Day
    {
        public static String input =
            // "0,9 -> 5,9\n8,0 -> 0,8\n9,4 -> 3,4\n2,2 -> 2,1\n7,0 -> 7,4\n6,4 -> 2,0\n0,9 -> 2,9\n3,4 -> 1,4\n0,0 -> 8,8\n5,5 -> 8,2";
            "645,570 -> 517,570\n100,409 -> 200,409\n945,914 -> 98,67\n22,934 -> 22,681\n935,781 -> 524,370\n750,304 -> 854,408\n974,27 -> 26,975\n529,58 -> 979,58\n979,515 -> 550,944\n925,119 -> 17,119\n178,594 -> 45,461\n252,366 -> 92,206\n25,593 -> 250,593\n956,34 -> 21,969\n200,671 -> 200,369\n628,614 -> 628,637\n697,428 -> 237,428\n554,40 -> 554,949\n927,197 -> 469,197\n504,779 -> 593,868\n227,882 -> 227,982\n56,905 -> 56,81\n438,874 -> 566,746\n989,73 -> 113,949\n82,36 -> 616,570\n670,423 -> 670,873\n100,435 -> 291,435\n242,81 -> 978,817\n367,335 -> 367,332\n890,584 -> 116,584\n572,192 -> 572,561\n391,516 -> 391,559\n525,62 -> 525,540\n787,540 -> 812,515\n749,732 -> 423,406\n745,911 -> 694,911\n805,18 -> 972,18\n701,565 -> 280,144\n930,92 -> 129,893\n15,989 -> 970,34\n409,920 -> 409,345\n192,743 -> 312,863\n724,12 -> 29,707\n323,664 -> 323,897\n161,423 -> 391,653\n59,363 -> 250,554\n407,676 -> 19,288\n449,585 -> 449,301\n914,798 -> 914,806\n917,401 -> 288,401\n588,800 -> 647,800\n897,883 -> 897,276\n115,606 -> 41,532\n692,482 -> 777,482\n428,736 -> 69,736\n405,44 -> 405,632\n198,482 -> 198,620\n988,816 -> 988,598\n254,461 -> 186,393\n560,783 -> 208,783\n856,766 -> 215,125\n182,30 -> 569,30\n504,242 -> 656,242\n393,929 -> 131,929\n597,359 -> 26,930\n502,690 -> 255,443\n149,608 -> 149,748\n293,662 -> 622,662\n697,154 -> 697,228\n587,804 -> 983,804\n715,63 -> 715,709\n496,831 -> 23,358\n461,48 -> 68,441\n927,565 -> 595,565\n972,350 -> 689,350\n728,438 -> 728,221\n173,134 -> 173,804\n720,368 -> 121,368\n690,66 -> 201,66\n218,680 -> 841,680\n80,792 -> 80,467\n624,319 -> 624,461\n248,348 -> 532,64\n357,260 -> 505,408\n296,814 -> 13,531\n819,216 -> 819,932\n696,233 -> 696,840\n219,93 -> 868,93\n537,63 -> 905,63\n777,940 -> 777,84\n286,133 -> 286,735\n969,967 -> 969,823\n254,222 -> 859,827\n426,728 -> 426,388\n854,561 -> 854,363\n755,861 -> 755,947\n570,754 -> 439,754\n333,351 -> 333,828\n436,693 -> 436,262\n982,987 -> 172,177\n267,178 -> 267,270\n218,201 -> 747,730\n811,602 -> 829,584\n602,659 -> 766,659\n536,544 -> 483,597\n280,881 -> 547,881\n584,125 -> 129,125\n386,210 -> 757,210\n605,855 -> 605,668\n19,985 -> 988,16\n980,655 -> 836,655\n73,189 -> 267,383\n621,645 -> 533,645\n36,12 -> 255,231\n538,889 -> 130,481\n921,217 -> 921,724\n873,59 -> 873,311\n76,918 -> 970,24\n694,448 -> 694,983\n573,891 -> 573,337\n796,358 -> 403,358\n532,928 -> 351,928\n123,717 -> 123,446\n874,714 -> 874,886\n350,458 -> 728,458\n798,140 -> 798,242\n832,406 -> 864,406\n188,55 -> 188,641\n903,376 -> 509,376\n50,954 -> 989,15\n42,294 -> 25,294\n544,273 -> 974,273\n804,756 -> 103,55\n398,184 -> 570,12\n82,179 -> 902,179\n461,728 -> 905,284\n429,241 -> 26,241\n128,715 -> 207,715\n239,545 -> 934,545\n978,769 -> 978,576\n250,77 -> 515,77\n521,533 -> 521,434\n955,844 -> 314,203\n144,601 -> 702,43\n313,784 -> 339,784\n388,692 -> 805,275\n540,872 -> 540,72\n971,19 -> 17,973\n816,540 -> 386,540\n933,246 -> 560,619\n800,600 -> 387,187\n272,791 -> 129,934\n908,133 -> 110,931\n759,191 -> 910,40\n420,479 -> 749,150\n604,946 -> 804,946\n633,404 -> 771,266\n948,974 -> 948,734\n735,198 -> 105,828\n889,653 -> 889,688\n157,172 -> 822,837\n206,670 -> 297,670\n50,122 -> 792,864\n656,664 -> 27,664\n966,33 -> 523,33\n985,40 -> 101,924\n394,367 -> 574,547\n440,573 -> 268,573\n159,989 -> 159,130\n867,123 -> 867,891\n316,153 -> 316,249\n680,59 -> 773,152\n52,928 -> 52,182\n128,595 -> 225,595\n508,719 -> 591,719\n595,447 -> 709,333\n930,783 -> 283,136\n366,236 -> 283,236\n820,512 -> 381,951\n135,450 -> 135,766\n750,838 -> 534,838\n259,304 -> 626,671\n414,631 -> 916,129\n193,862 -> 901,154\n362,595 -> 362,209\n377,215 -> 377,499\n723,16 -> 577,16\n335,238 -> 790,693\n670,266 -> 871,65\n288,313 -> 213,313\n48,423 -> 592,967\n960,323 -> 911,323\n177,182 -> 177,235\n773,918 -> 757,918\n216,432 -> 147,432\n808,500 -> 656,500\n205,451 -> 776,451\n598,985 -> 598,608\n193,253 -> 241,205\n912,384 -> 912,532\n214,194 -> 214,738\n508,356 -> 508,792\n16,372 -> 30,372\n384,854 -> 986,252\n361,569 -> 851,569\n923,550 -> 923,441\n271,257 -> 318,304\n651,345 -> 651,397\n885,14 -> 929,14\n199,547 -> 925,547\n803,176 -> 104,875\n840,302 -> 197,945\n971,743 -> 355,127\n684,951 -> 684,292\n58,867 -> 58,953\n351,187 -> 351,831\n701,413 -> 701,728\n482,159 -> 134,159\n118,52 -> 950,884\n115,968 -> 115,137\n437,739 -> 627,929\n653,153 -> 549,153\n604,504 -> 560,460\n538,865 -> 840,563\n114,876 -> 114,124\n152,899 -> 925,126\n973,224 -> 973,387\n492,360 -> 861,729\n927,902 -> 108,83\n754,678 -> 754,647\n526,671 -> 423,671\n675,608 -> 243,608\n147,241 -> 147,242\n456,770 -> 456,665\n953,50 -> 102,901\n415,869 -> 415,733\n979,533 -> 169,533\n336,385 -> 336,18\n927,176 -> 927,587\n370,317 -> 933,880\n450,349 -> 450,103\n755,235 -> 408,235\n342,55 -> 931,55\n417,707 -> 887,237\n141,95 -> 131,85\n776,209 -> 590,23\n39,732 -> 469,302\n743,602 -> 743,358\n473,439 -> 473,545\n270,290 -> 270,640\n904,963 -> 949,963\n71,91 -> 956,976\n865,757 -> 276,757\n59,72 -> 966,979\n46,184 -> 788,926\n360,833 -> 561,833\n120,452 -> 528,452\n704,927 -> 158,381\n140,481 -> 140,350\n929,920 -> 929,342\n328,381 -> 328,866\n897,389 -> 227,389\n341,614 -> 29,614\n609,327 -> 609,582\n727,858 -> 727,941\n349,536 -> 349,500\n280,959 -> 259,959\n973,637 -> 832,637\n161,255 -> 979,255\n512,826 -> 149,826\n308,769 -> 22,769\n60,692 -> 60,262\n787,31 -> 753,31\n932,166 -> 932,127\n514,77 -> 514,646\n535,434 -> 535,979\n838,799 -> 838,332\n565,956 -> 565,477\n74,195 -> 274,195\n916,715 -> 907,715\n721,655 -> 721,542\n180,784 -> 928,784\n16,128 -> 313,128\n23,330 -> 23,704\n530,723 -> 530,88\n869,272 -> 765,376\n878,185 -> 353,185\n72,800 -> 514,800\n319,117 -> 307,117\n436,405 -> 496,345\n327,459 -> 641,145\n358,309 -> 661,612\n60,225 -> 811,976\n113,130 -> 794,130\n559,950 -> 32,423\n626,110 -> 626,319\n50,39 -> 989,978\n257,627 -> 799,627\n581,843 -> 581,493\n869,18 -> 208,18\n184,395 -> 184,263\n454,888 -> 165,599\n637,920 -> 637,544\n170,982 -> 273,982\n98,354 -> 668,924\n32,409 -> 32,925\n154,175 -> 273,294\n425,896 -> 870,451\n198,319 -> 615,736\n170,582 -> 170,712\n141,645 -> 141,639\n482,768 -> 486,768\n940,969 -> 24,53\n680,360 -> 959,360\n315,905 -> 315,96\n22,666 -> 22,247\n722,40 -> 722,714\n585,31 -> 585,21\n479,254 -> 307,254\n291,182 -> 291,855\n684,698 -> 402,698\n20,984 -> 988,16\n256,424 -> 17,663\n825,380 -> 820,385\n254,622 -> 254,315\n98,855 -> 98,694\n220,719 -> 220,117\n615,653 -> 656,694\n427,12 -> 427,745\n20,64 -> 828,872\n739,203 -> 434,203\n546,576 -> 130,160\n730,835 -> 299,835\n927,512 -> 927,586\n411,192 -> 868,192\n917,630 -> 678,630\n620,588 -> 620,26\n786,488 -> 486,488\n746,640 -> 251,145\n585,556 -> 585,119\n977,202 -> 762,202\n587,244 -> 587,877\n693,479 -> 693,859\n59,816 -> 59,475\n191,941 -> 878,254\n150,920 -> 926,144\n856,397 -> 856,739\n380,965 -> 549,796\n637,323 -> 909,595\n848,219 -> 304,763\n123,146 -> 589,146\n546,122 -> 651,122\n131,711 -> 814,28\n727,274 -> 296,274\n101,546 -> 479,168\n508,517 -> 615,410\n492,115 -> 492,250\n212,65 -> 770,623\n118,938 -> 857,199\n623,843 -> 98,843\n86,153 -> 701,768\n81,98 -> 81,604\n173,313 -> 173,533\n792,396 -> 792,242\n975,985 -> 10,20\n762,661 -> 726,661\n216,327 -> 216,122\n446,658 -> 98,658\n85,184 -> 314,184\n165,750 -> 313,750\n729,583 -> 729,640\n382,36 -> 382,326\n487,32 -> 225,32\n389,722 -> 582,915\n954,965 -> 86,965\n747,376 -> 747,96\n254,259 -> 254,482\n149,256 -> 149,871\n893,207 -> 708,22\n195,907 -> 195,82\n342,686 -> 457,571\n647,469 -> 468,469\n150,525 -> 832,525\n90,907 -> 90,31\n389,554 -> 389,318\n138,327 -> 138,310\n861,126 -> 861,549\n355,583 -> 355,534\n591,182 -> 181,592\n73,84 -> 897,908\n326,989 -> 425,989\n835,688 -> 724,799\n844,493 -> 844,974\n172,436 -> 172,12\n536,933 -> 48,445\n192,531 -> 287,531\n286,547 -> 80,547\n929,795 -> 697,795\n790,681 -> 433,681\n692,229 -> 731,229\n377,667 -> 14,304\n535,226 -> 116,645\n338,861 -> 338,343\n668,160 -> 853,160\n188,157 -> 667,636\n62,934 -> 951,45\n948,820 -> 978,820\n860,884 -> 157,884\n794,251 -> 783,251\n317,381 -> 591,655\n459,876 -> 459,307\n146,822 -> 903,65\n374,739 -> 891,739\n619,575 -> 973,929\n544,351 -> 544,124\n300,335 -> 818,335\n158,220 -> 418,480\n107,953 -> 988,953\n304,753 -> 543,753\n948,95 -> 140,903\n832,451 -> 526,145\n966,34 -> 402,598\n72,123 -> 716,123\n336,294 -> 84,294\n116,605 -> 116,889\n700,742 -> 700,217\n551,554 -> 973,554\n684,181 -> 66,799\n86,949 -> 86,173\n834,361 -> 834,942\n508,668 -> 627,549\n213,695 -> 704,695\n260,979 -> 868,371\n825,435 -> 825,67\n956,854 -> 66,854\n390,444 -> 697,444\n360,450 -> 720,810\n153,514 -> 794,514\n253,261 -> 253,298\n925,679 -> 925,499\n391,282 -> 441,282\n86,366 -> 779,366\n687,312 -> 687,629\n304,172 -> 732,600\n571,518 -> 263,518\n814,252 -> 118,252\n108,920 -> 108,162\n154,965 -> 928,191\n635,875 -> 635,947\n986,31 -> 47,970\n746,35 -> 746,636\n735,849 -> 334,448\n826,510 -> 906,590\n834,745 -> 834,949\n843,401 -> 564,122\n179,212 -> 179,32\n354,906 -> 233,906\n593,439 -> 196,42\n707,446 -> 242,446\n511,84 -> 511,406\n109,299 -> 100,290\n410,79 -> 410,784\n806,923 -> 54,171\n592,83 -> 592,189\n413,28 -> 413,469\n17,844 -> 17,691\n130,419 -> 205,344\n374,247 -> 849,247\n650,344 -> 653,344\n563,942 -> 563,726\n771,966 -> 450,966\n499,693 -> 788,693\n962,458 -> 962,356\n28,683 -> 765,683\n432,546 -> 432,708\n519,974 -> 176,974\n797,744 -> 280,227\n505,228 -> 547,228\n401,366 -> 401,754\n356,470 -> 123,470\n57,909 -> 229,909\n343,880 -> 539,880\n221,851 -> 221,297\n520,677 -> 894,677\n216,805 -> 688,805\n158,901 -> 847,901\n98,129 -> 98,969\n793,203 -> 210,786\n852,855 -> 135,138\n944,90 -> 103,931\n691,768 -> 583,768\n784,617 -> 637,764\n222,160 -> 819,757\n145,982 -> 145,216\n837,355 -> 99,355\n324,121 -> 324,14\n773,851 -> 773,413\n778,550 -> 686,458\n81,56 -> 338,313\n356,512 -> 356,441";

        public static String[] bounds = input.Split("\n");

        public void PuzzleOne()
        {
            // Find the max for this input
            int[] limits = GetMaxDirection(bounds);
            int maxDirectionY = limits[1] + 1, maxDirectionX = limits[0] + 1;
            int[,] grid = new int[maxDirectionY, maxDirectionX];

            foreach (String bound in bounds)
            {
                String[] positions = bound.Split(" -> ");

                int[] firstPosition = Array.ConvertAll(positions[0].Split(","), s => int.Parse(s));
                int[] secondPosition = Array.ConvertAll(positions[1].Split(","), s => int.Parse(s));

                FillGrid(grid, firstPosition, secondPosition, false);
            }

            Console.WriteLine($"Answer: {count(grid, maxDirectionY, maxDirectionX)}");
        }

        public void PuzzleTwo()
        {
            // Find the max for this input
            int[] limits = GetMaxDirection(bounds);
            int maxDirectionY = limits[1] + 1, maxDirectionX = limits[0] + 1;
            int[,] grid = new int[maxDirectionY, maxDirectionX];

            foreach (String bound in bounds)
            {
                String[] positions = bound.Split(" -> ");

                int[] firstPosition = Array.ConvertAll(positions[0].Split(","), s => int.Parse(s));
                int[] secondPosition = Array.ConvertAll(positions[1].Split(","), s => int.Parse(s));

                FillGrid(grid, firstPosition, secondPosition, true);
            }
 
            Console.WriteLine($"Answer: {count(grid, maxDirectionY, maxDirectionX)}");
        }

        public static int count(int[,] grid, int xSize, int ySize)
        {
            int countIntersect = 0;
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    if (grid[y, x] > 1) countIntersect++;
                }
            }

            return countIntersect;
        }
        
        public static void FillGrid(int[,] grid, int[] firstPosition, int[] secondPosition, bool diagonals)
        {
            int x1 = firstPosition[0], x2 = secondPosition[0];
            int y1 = firstPosition[1], y2 = secondPosition[1];

            if (!diagonals)
            {
                for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                {
                    for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                    {
                        if (x1 == x2 || y1 == y2) grid[y, x]++;
                    }
                }
            }
            else
            {
                // Thanks Andie :p
                int xDiff, yDiff;

                if (x1 > x2) xDiff = -1;
                else if (x1 < x2) xDiff = +1;
                else xDiff = 0;

                if (y1 > y2) yDiff = -1;
                else if (y1 < y2) yDiff = +1;
                else yDiff = 0;

                do
                {
                    grid[x1, y1] += 1;

                    if (x1 == x2 && y1 == y2) break;

                    x1 += xDiff;
                    y1 += yDiff;
                } while (true);
            }
        }

        public int[] GetMaxDirection(String[] boundList)
        {
            int[] maxDirection = new int[2];

            foreach (string bound in boundList)
            {
                String[] positions = bound.Split(" -> ");

                foreach (String position in positions)
                {
                    int[] xySplit = Array.ConvertAll(position.Split(","), s => int.Parse(s));

                    // X
                    if (maxDirection[0] < xySplit[0]) maxDirection[0] = xySplit[0];

                    // Y
                    if (maxDirection[1] < xySplit[1]) maxDirection[1] = xySplit[1];
                }
            }

            return maxDirection;
        }
    }
}
