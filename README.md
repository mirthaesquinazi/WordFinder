# WordFinder
This solution has one endpoint 

/words 

Given a IEnumerable<string> named matrix and a IEnumerable<string> named stream
The endpoint return the top 10 most repeated words from the word stream found in the
matrix.

- The matrix size shouldnt exceed 64x64 and all strings must contain the same number of characters.
- If no words are found, the "Find" method should return an empty set of strings.
- If any word in the word stream is found more than once within the stream, the search results
should count it only once 
- Words may appear horizontally, from left to right, or vertically, from top to bottom.

There are comments throughout the solution that explain some performance decisions and unit tests that check important use cases.

Dev: Mirtha Esquinazi
