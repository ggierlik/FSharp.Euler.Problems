module ep2
//http://projecteuler.net/problem=2

//Fibonacci sequence generator
let fibSeq = Seq.unfold (fun (a, b) -> Some (a+b, (b, a+b))) (0, 1)

let solve =
    fibSeq |> Seq.takeWhile (fun x -> x < 4000000) |> Seq.filter (fun x -> x % 2 = 0) |> Seq.sum
