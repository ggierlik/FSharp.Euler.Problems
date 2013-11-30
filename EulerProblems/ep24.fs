module ep24
//http://projecteuler.net/problem=24

(*
number of permutations on n elements set is n!
9!      = 362880
9!*2    = 725760

1.       0123456789
725761.  2013456789

10^6-2*9!   = 274240
8!          = 40320

274240 / 40320  = 6.8
40320 * 6       = 241920

725760 + 241920 = 967680

967680. 2013
0123
0132
01 23
02 13
0213
0231

*)

let perm = [0..9]

let get_longest_tail lst = 

    let rec get_tail acc lst =
        printfn "%A %A" acc lst

        let h = List.head lst    
        let e = List.head acc

        printfn "%d %d" h e

        if e < h then get_tail (h::acc) (List.tail lst)
        else (h, lst |> List.tail |> List.rev, acc)

    let l = List.rev lst
    get_tail [List.head l] (List.tail l)

let get_first_greater lst elem = 
    lst |> List.filter (fun e -> e > elem) |> List.head

let next_perm perm =
    
    let e, tail, lst = get_longest_tail perm

    printfn "%d %A" e tail

    let g = get_first_greater tail e

    perm
