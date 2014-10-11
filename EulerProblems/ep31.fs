module ep31
//http://projecteuler.net/problem=31

//[<Measure>] type p
//[<Measure>] type P

//returns infinite sequence of n (value of coin)
let getInfSeq n = Seq.unfold (fun i -> Some(i, i)) n

let coins = [1; 2; 5] //; 10; 20; 50; 100; 200]

let TOTAL = 200

let coinsSeq = coins |> List.map (fun i -> getInfSeq i)

let solve total =
    let rec calc acc sum coins =
        printfn "acc: %d sum: %d" acc sum

        if List.isEmpty coins then acc
        else
            let m = coins |> List.head

            let new_sum = sum + m
            printfn "acc: %d sum: %d m: %d new_sum: %d coins: %A" acc sum m new_sum coins

            if new_sum = total then calc (acc+1) (sum) (coins |> List.tail)
            else if new_sum < total then calc acc new_sum coins
            else calc acc (sum) (coins |> List.tail)

    calc 0 0 coins

solve 5 |> printfn "%d"