{-
 -  This file is part of the CodeJamCollection.
 -
 -  CodeJamCollection is free software: you can redistribute it and/or modify
 -  it under the terms of the GNU General Public License as published by
 -  the Free Software Foundation, either version 3 of the License, or
 -  (at your option) any later version.
 -
 -  CodeJamCollection is distributed in the hope that it will be useful,
 -  but WITHOUT ANY WARRANTY; without even the implied warranty of
 -  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 -  GNU General Public License for more details.
 -
 -  You should have recieved a copy of the GNU General Public License
 -  along with CodeJamCollection. If not, see <http://www.gnu.org/license/>.
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
