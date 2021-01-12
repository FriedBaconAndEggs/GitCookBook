open System.Text.RegularExpressions
open System.IO;
open System

let (|Heading|_|) i =
    let m = Regex.Match (i, @"(?m)^\s*(#)+\s+(.+)\r?$")
    if m.Success then
        Some (m.Groups.[1].Captures.Count, m.Groups.[2].Value)
    else
        None

let mark = function
    | 2 -> "*"
    | 3 -> "+"
    | _ -> "-"

let parseHeading = function
    | Heading (nesting, value) -> 
        Some (sprintf "%s%s [%s](#%s)"
            (String.replicate (nesting - 1) "    ")
            (mark nesting)
            value
            (Regex.Replace (value, @"\s", "-")))
    | _ -> None

let parseTocText = Array.map parseHeading >> Array.choose id

let updateToc (readme : string) (newTocText : string) =
    Regex.Replace(readme, @"(?ms)(?<=#+\s+Table of contents\s*\r?\n).+?(?=\r?\n^\s*#+\s*\w+)", newTocText)

let removeCodeBlocks str = Regex.Replace(str, @"(?ms)^```.+?```\r?$", "")

let readmeText = File.ReadAllText "README.md"

readmeText
    |> removeCodeBlocks
    |> fun s -> Regex.Split(s, Environment.NewLine)
    |> parseTocText
    |> String.concat Environment.NewLine
    |> updateToc readmeText
    |> fun t -> File.WriteAllText("README.md", t)