module ep36
//https://projecteuler.net/problem=36

open System

//let f n = Seq.unfold (fun n -> if n = 0 then None else Some (n%2,n/2)) n |> Seq.toList |> List.rev

let int2bin (n:int) =
    System.Convert.ToString(n, 2)

let toArray (s:string) =
    s.ToCharArray()

let rev (s : string) = 
    new String(Array.rev (s.ToCharArray()))

let solve n =
    let numbers = [1..n]
    //let trd (_, _, t) = t

    numbers
    |> List.map (fun n -> (n, System.Convert.ToString(n))) //to string
    |> List.filter (fun (n, s) -> s = (rev s))             //filter out non dec palindroms 
    |> List.map(fun (n, s) -> (n, s, int2bin n))           //bin number added 
    |> List.filter(fun (n, sn, sb) -> sb = (rev sb))       //filter out non bin palindroms
    |> List.sumBy (fun (n, _, _) -> n)                     //sum up 
