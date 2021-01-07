open System.Text.RegularExpressions
open System.IO;
open System

let (|Heading|_|) i =
  let m = Regex.Match (i, @"(?m)^\s*(#)+\s+(.+)\r?$")
  if m.Success then
    Some (m.Groups.[1].Captures.Count, m.Groups.[2].Value)
  else
    None

let mark =
    fun nesting ->
        match nesting with
            | 2 -> "*"
            | 3 -> "+"
            | _ -> "-"

let parseHeading str =
    match str with
        | Heading (nesting, value) -> 
            Some (String.replicate (nesting - 1) "    " + 
                sprintf "%s [%s](#" (mark nesting) value +
                Regex.Replace (value, @"\s", "-") +
                ")")
        | _ -> None

let parseTocText readmeLines =
    readmeLines
        |> Array.map parseHeading
        |> Array.where (fun x -> x.IsSome)
        |> Array.map (fun x -> x.Value)

let updateToc (readme : string) (newTocText : string) =
    Regex.Replace(readme, @"(?ms)(?<=#+\s+Table of contents\s*\r?\n).+?(?=^\s*#+\s*\w+)", newTocText)

let removeCodeBlocks str =
    Regex.Replace(str, @"(?ms)^```.+?```\r?$", "")

let readmeText = File.ReadAllText "README.md"

readmeText
    |> removeCodeBlocks
    |> (fun s -> Regex.Split(s, Environment.NewLine))
    |> parseTocText
    |> String.concat Environment.NewLine
    |> updateToc readmeText
    |> printfn "%s"