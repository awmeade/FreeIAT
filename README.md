# FreeIAT
Public repository for the FreeIAT program

See http://www4.ncsu.edu/~awmeade/FreeIAT/FreeIAT.htm

<h2>Frequently Asked Questions</h2>
 
Can I run the program from a USB drive?

Yes! Just put the FreeIAT.exe and config.txt files on a USB drive and run them from anywhere (e.g., computer lab). Note, however, that the "check for updates" feature will not work without other files installed.

I get an error that looks like System.UnauthorizedAccessException: Access to the path 'C:\Program Files (x86)\FreeIAT 1.3.3\AllData.txt' is denied.

This is almost always caused by trying to run the program from a directory that is 'read-only'. Right-click on both the files and the directory and make sure 'read-only' is not checked. Also try running the program from a USB drive.
 
Can the program counter-balance the order in which the pairs are administered ?

Currently, no - but by design. There appear to be order effects such that the first set of pairings are typically faster than the second set (i.e., Block 3 is faster than Block 5). It is intuitively appealing to "control" for this via counter-balancing. However, this is a bad idea for most applications. If the goal is to get an accurate mean estimate of the population IAT scores, then by all means counter-balancing is appropriate. However, most researchers treat IAT scores as individual difference variables for which correlations with other variables will be computed. Given the arbitrary metric of IATs, mean values are seldom of interest. Therefore, it is best to hold the order effect constant across all respondents by using the same administration order so as not to introduce systematic construct-irrelevant (i.e., error) variance into your data. 

If you insist on counter-balancing, simply create two versions of your IAT.  Just copy all of the files from your IAT directory into a second directory and change the Config.txt file.  Then you can simply run either IAT program you wish in counter-balanced order.

The IAT won't load - I get an error saying the program won't start

Most likely you are trying to run the program on a computer that does not have version 3.5 of Microsoft's .NET Framework installed.  You can download that here.

Can the program collect data via the internet?

No.

How accurate is the response time measure in the FreeIAT?

Short answer: I don't know. I'm not sure how one would go about testing the accuracy of response time in a program such as this. However, the program uses Microsoft's .net framework and the time is assessed with your computer's clock. Bias and accuracy are entirely different issues. Accuracy relates to how close to actual reaction time the measure of reaction time is. Bias relates to systematic error in measurement (for instance consistently over-reporting the response time in only Block 3 but not the other blocks). It's impossible for me to see any way that bias (i.e., consistently underestimating only one block of responses) would result given the code. The code used in Blocks 3 and 5 (which fully determine the IAT score) is identical. If there is error (say the clock is off by a few thousandths of a second) it is dwarfed by the inherent error present in any psychological measure. Said differently, the IAT as a method has thousands of times more error than any computer clock inaccuracy. I can't see how this would be an issue.

How do I find out validity and reliability information for the FreeIAT?

It's important to remember that the FreeIAT is just software. More generally, IATs are methods of collecting data that relate to particular constructs (such as attitudes). The reliability and validity of any IAT will depend largely on the content you supply when creating your IAT. You can search the literature for meta-analyses on the average reliability of IATs, but your IAT may vary quite a lot from any average. You should calculate reliability and establish validity for any IAT you create. The FreeIAT provides split-half scores, the correlation of which can be computed and corrected via the Spearman-Brown to provide an estimate of reliability for your measure.

 
How do I interpret the scores?

Give a close read to the How it Works section. The final score is computed as Block 5 - Block 3. Therefore a positive scores means the items paired in Block 5 has a WEAKER association than those paired in Block 3. Thus, there is a preference for the Block 3 pairings over the Block 5 pairings. 
