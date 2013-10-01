module ep15
//http://projecteuler.net/problem=15

//let mutable grid = Array2D.create 2 2 0UL
let mutable grid = Array2D.create 4 4 (0UL, false)

let solve N = 
    let leafsSeq (n, m) =
        seq {
            if n < N then yield (n+1, m)
            if m < N then yield (n, m+1)
        }

    let rec calc acc (n, m) =
        let mutable a = acc
        printfn "%d %d %d %A\n***\n" a n m grid.[n, m]

        if fst grid.[n, m] <> 0UL then 
            fst grid.[n, m] + 1UL
        else
            let leafs = leafsSeq (n, m)

            if Seq.length leafs = 0 then
                a <- a+1UL

            for l in leafs do
                printfn "%d %A" a l
                a <- calc a l

            grid.[n, m] <- (a, true)
            printfn "%A\n***\n" grid
            a

    calc 0UL (0, 0)

solve 3 |> printfn "%d"


//solve 3 |> printfn "%d"
//solve 5 |> printfn "%d"
//solve 10 |> printfn "%d"
//solve 15 |> printfn "%d"
//solve 20 |> printfn "%d"


