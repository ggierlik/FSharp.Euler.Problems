module ep21
//http://projecteuler.net/problem=21

(*
d(n) = s
d(s) = n
*)

(*
31626
Time 4.269296s
*)
let divisors_old n =
    seq { for i in 1..n/2 do if n % i = 0 then yield i}
         
(*
31626
Time 0.488435s
*)
let divisors n =
    let bf = n |> float |> sqrt
    let bound = (bf |> ceil |> int)

    seq { for i in 1..bound do 
            if n % i = 0 then 
                yield i
                if i <> 1 && i*i <> n then yield n/i
        }
           
let d n =
    divisors n |> Seq.sum

let numbers = [0..10000]

let sum_of_divs = numbers |> List.map(fun n -> d n) |> List.toArray

let amicable_numbers =
    seq { for i in 1..10000 do 
            let s = sum_of_divs.[i]
            let k = if s > 10000 then d s else sum_of_divs.[s]
                
            if k = i && i <> s then 
                // printfn "%d %d %d" i s k
                yield k
                yield i
        }

let solve () = 
    amicable_numbers 
        |> Seq.distinct 
        |> Seq.reduce (+)



