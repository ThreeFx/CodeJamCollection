{-
 -  The MIT License (MIT)
 -  
 -  Copyright (c) <year> <copyright holders>
 -  
 -  Permission is hereby granted, free of charge, to any person obtaining a copy
 -  of this software and associated documentation files (the "Software"), to deal
 -  in the Software without restriction, including without limitation the rights
 -  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 -  copies of the Software, and to permit persons to whom the Software is
 -  furnished to do so, subject to the following conditions:
 -  
 -  The above copyright notice and this permission notice shall be included in
 -  all copies or substantial portions of the Software.
 -  
 -  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 -  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 -  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 -  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 -  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 -  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 -  THE SOFTWARE.
 -}

-- | Haskell boilerplate code for Google Code Jam.
module Main where

-- | Imports (add if necessary)
import Data.List (intercalate)
import Data.List.Split (splitOneOf)
import System.Environment (getArgs)

-- | Type synonym for more readability
type Solver = [String] -> String

-- | Main function.
main = output getLine . solveAllCases =<< getProblems =<< getArgs
  where
    solveAllCases = format . solveAll solveCase . drop 1


-- | Solves a single case.
solveCase :: Solver
solveCase = concat  -- Adjust me!


-- | The important filepaths. Adjust if necessary.
downloadDirectory = "C:\\Users\\Ben\\Downloads\\"
uploadDirectory   = "C:\\Users\\Ben\\Desktop\\codejam\\"

-- | Returns a list of 
format :: [String] -> [String]
format = map prettify . zip [1..]
  where
    prettify (i, solution) = "Case #" ++ show i ++ ": " ++ solution

-- | Solves all cases using the specified solver.
solveAll :: Solver -> [String] -> [String]
solveAll _         []  = []
solveAll solveFunc str = solveFunc input : solveAll solveFunc rest
  where
    input = take lines str
    rest = drop lines str
    lines = 1 --  Change this according to the number of lines the case has.

-- | Reads the cases from the file specified at program start.
-- Returns the file line by line.
getProblems :: [String] -> IO [String]
getProblems args = fmap lines $ readFile filepath
  where
    filepath = downloadDirectory ++ intercalate "-" args ++ ".in"

-- | Writes the solved cases to the specified file.
output :: IO String -> [String] -> IO ()
output name str = flip writeFile (unlines str) =<< filename
  where
    filename = fmap (\n -> uploadDirectory ++ n ++ ".out") name


-- | Functions to get numbers from strings.

-- | Converts the string to a single
readSingle :: Read a => String -> a
readSingle = read

readMany :: Read a => String -> [a]
readMany = readManyWithSep " "

readManyWithSep :: Read a => String -> String -> [a]
readManyWithSep sep = map read . splitOneOf sep

readField :: Read a => [String] -> [[a]]
readField = readFieldWithFunc readMany

readFieldWithFunc :: (String -> [a]) -> [String] -> [[a]]
readFieldWithFunc f = map f
