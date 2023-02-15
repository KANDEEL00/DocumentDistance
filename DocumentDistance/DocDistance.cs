using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDistance
{
    class DocDistance
    {
        // *****************************************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // *****************************************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>
        public static HashSet<string> allWords = new HashSet<string>();
        public static Dictionary<string, long> separateDoc(ref string doc)
        {
            var docWords = new Dictionary<string, long>();
            doc = doc.ToLower();
            string tmpWord = "";
            int sz = doc.Length;
            for (int i = 0; i <= sz; i++)
            {
                if ( i != sz && ( (doc[i] >= 'a' && doc[i] <= 'z') || (doc[i] >= '0' && doc[i] <= '9') ) )
                    tmpWord += doc[i];
                else if (tmpWord != "")
                {
                    if (docWords.ContainsKey(tmpWord))
                        docWords[tmpWord]++;
                    else
                        docWords[tmpWord] = 1;
                    allWords.Add(tmpWord);
                    tmpWord = "";
                }
            }
            return docWords;
        }
        public static double angleBetweenTwoVectors(string firstDoc, string secondDoc)
        {
            // split First & Second Documents
            var firstDocWords = separateDoc(ref firstDoc);
            var secondDocWords = separateDoc(ref secondDoc);
            // find diffirence between the two Docs
            double dotProd = 0, firstDocEcldDist = 0, secondDocEcldDist = 0;
            foreach (var w in allWords)
            {
                firstDocWords.TryGetValue(w, out long reptOfWrdFirstDoc);
                secondDocWords.TryGetValue(w, out long reptOfWrdSecondDoc);
                dotProd += reptOfWrdFirstDoc * reptOfWrdSecondDoc;
                firstDocEcldDist += Math.Pow(reptOfWrdFirstDoc, 2);
                secondDocEcldDist += Math.Pow(reptOfWrdSecondDoc, 2);
            }
            double crossProd = Math.Sqrt(firstDocEcldDist * secondDocEcldDist);
            Console.WriteLine();
            //Console.WriteLine(dotProd);
            //Console.WriteLine(crossProd);
            double angleInRadius = dotProd / crossProd;
            angleInRadius = Math.Acos(angleInRadius);
            double angleInDegrees = (180 / Math.PI) * angleInRadius;
            if (Double.IsNaN(angleInDegrees)) angleInDegrees = 90;
            //Console.WriteLine(angleInDegrees);
            //angleInDegrees = Math.Round(angleInDegrees, 1);
            return angleInDegrees;
        }
        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // TODO comment the following line THEN fill your code here
            //throw new NotImplementedException();
            string doc1 = File.ReadAllText(doc1FilePath);
            //Console.WriteLine(doc1);
            string doc2 = File.ReadAllText(doc2FilePath);
            //Console.WriteLine(doc2);
            return angleBetweenTwoVectors(doc1, doc2);
        }
    }
}
