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
        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // TODO comment the following line THEN fill your code here
            //throw new NotImplementedException();

            
            double angle = 0;
            return angle;
        }

        HashSet<string> allWords;
        public static void separateDoc(ref string doc, ref Dictionary<string, int> docWords)
        {
            doc.ToLower();
            //Console.WriteLine(doc);
            
            string tmpWord="";
            int sz = doc.Length;
            for (int i = 0; i <= sz; i++)
            {
                if (doc[i] >= 'a' && doc[i] <= 'z' && i != sz)
                    tmpWord.Append(doc[i]);
                else
                {
                    if (tmpWord=="")
                    {
                        docWords[tmpWord]++;
                        //allWords.insert(tmpWord);
                        //tmpWord.clear();
                    }
                }
            }

            /*
            //check map 'DocWords'
            cout<<"check map 'DocWords'"<<endl;
            int cnt=0;
            for(auto w:docWords){
                cout<<w.first<<" "<<w.second<<endl;
                cnt+=w.second;
            }
            cout<<cnt<<endl;
            */
            
        }
    }
}
