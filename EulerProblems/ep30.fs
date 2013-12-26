module ep30

//http://projecteuler.net/problem=30

let digits n = 
    Seq.unfold (fun n -> if (n = 0) then None else Some(n % 10, n/10)) n
    
(*
9^5 = 59049
6 * 9^5 = 354294
7 * 9^5 = 413343

354294 seems to be last number to check
*)

let N = 354294

let sum_of_digits_powers n N =
    let numbers = seq {1..N}

    let sum a b =
        digits a 
        |> Seq.map (fun d -> pown d b)
        |> Seq.reduce (+)

    numbers 
    |> Seq.map (fun m -> (m, sum m n))
    |> Seq.filter (fun (m, sm) -> (m = sm && m <> 1))
    |> Seq.map (fun (m, _) -> m)


let solve n =
    sum_of_digits_powers n N
    |> Seq.reduce (+)
