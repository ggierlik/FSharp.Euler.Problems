module ep3
//http://projecteuler.net/problem=3
//What is the largest prime factor of the number 600851475143 ?

let sfactors n = 
    Seq.unfold (fun state -> 
        let (m, p) = state
//        printfn "%d %d" m p

        if m = 1L then None
        elif m % p = 0L then Some(p, (m/p, p))
        else Some(1L, (m, p+1L))
    ) (n, 2L) |> Seq.filter (fun i -> i <> 1L)

//let q = sfactors 60085L
let q = sfactors 600851475143L
for x in q do printf "%d " x

//printfn "\nlast factor: %d" (Seq.last q) //doesn't not exists in Microsoft (R) F# 2.0 Interactive build 4.0.40219.1
printfn "\nlast factor: %d" (Seq.max q)
printfn "\nlast factor: %d" (q |> Seq.toList |> List.rev |> List.head)
