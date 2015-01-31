module ep36
//https://projecteuler.net/problem=36

//let f n = Seq.unfold (fun n -> if n = 0 then None else Some (n%2,n/2)) n |> Seq.toList |> List.rev

let int2bin (n:int) =
    System.Convert.ToString(n, 2)

let toArray (s:string) =
    s.ToCharArray()

let solve n =
    let numbers = [1..n]
    let trd (_, _, t) = t

    numbers
    |> List.map(fun n -> (System.Convert.ToString(n), int2bin n, n))
    |> List.map(fun (sn, sb, n) -> (sn |> toArray, sb |> toArray, n))
    |> List.filter(fun (sn, sb, n) -> sn = (sn |> Array.rev) && sb = (sb |> Array.rev))
    //|> List.map (fun x -> trd x)
    //|> List.sum
    |> List.sumBy (fun x -> trd x)
