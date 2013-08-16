module ep3
//http://projecteuler.net/problem=3
//What is the largest prime factor of the number 600851475143?

let private factors n = 
    Seq.unfold (fun state -> 
        let (m, d) = state
//        printfn "%d %d" m d

        if m = 1L then None
        elif m % d = 0L then Some(d, (m/d, d))
        else Some(1L, (m, d+1L))
    ) (n, 2L) |> Seq.filter (fun i -> i <> 1L)

let solve =
    //let ps = sfactors 60085L
    let ps = factors 600851475143L
    //for x in ps do printf "%d " x
    //Seq.last q //doesn't not exists in Microsoft (R) F# 2.0 Interactive build 4.0.40219.1
    //ps |> Seq.toList |> List.rev |> List.head
    ps |> Seq.max

//printfn "\nlast factor: %d" (Seq.last q) //doesn't not exists in Microsoft (R) F# 2.0 Interactive build 4.0.40219.1
//printfn "\nlast factor: %d" (Seq.max q)
//printfn "\nlast factor: %d" (q |> Seq.toList |> List.rev |> List.head)
