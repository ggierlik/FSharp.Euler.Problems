module ep28

//http://projecteuler.net/problem=28

(*
1, 1
3, 5, 7, 9, 3x3 = 8
13, 17, 21, 25, 5x5 = 16
31, 37, 43, 49, 7x7 = 24
*)

let numbers n = 
    Seq.unfold (fun (p, px, nt) ->
        if px > n then None
        else
            let pn = p+px
            if nt >= 4 then Some(pn, (pn, px+2, 1))
            else Some(pn, (pn, px, nt+1))
    ) (1, 0, 5)

let solve n =
    numbers n |> Seq.sum
