module ep24
//http://projecteuler.net/problem=24

(*
number of permutations on n elements set is n!
*)

let get_longest_tail lst = 

    let rec get_tail acc lst =
//        printfn "get_tail(1): %A %A" acc lst

        let h = List.head lst    
        let e = List.head acc

//        printfn "get_tail(2): %d %d" h e

        if e < h then get_tail (h::acc) (List.tail lst)
        else (h, lst |> List.tail |> List.rev, acc)

    let l = List.rev lst
    get_tail [List.head l] (List.tail l)

let get_first_greater lst elem = 
//    printfn "get_first_greater: %A %d" lst elem
    lst 
    |> List.filter (fun e -> e > elem) 
    |> List.sort 
    |> List.head

let next_perm perm =
    
    let e, lst, tail = get_longest_tail perm

//    printfn "%d %A %A" e lst tail

    let g = get_first_greater tail e

    let new_tail = 
        tail 
        |> List.map (fun i -> if i = g then e else i)
        |> List.sort

//    printfn "%d %d %A %A" e g tail new_tail

    List.append lst (g::new_tail)

let get_nth_perm n start_perm =
    let rec get_next_perm acc perm =
        
//        if acc % 1000 = 0 then printfn "get_nth_perm: %d %A" acc perm

        let next = next_perm perm
        
        if (acc+1) = n 
        then next
        else get_next_perm (acc+1) next

    let n_perm = get_next_perm 1 start_perm

    n_perm

let convert lst =
    lst
    |> List.map (fun i -> (i + int '0') |> char |> string)
    |> List.reduce (fun acc ch -> acc+ch)


let solve n perm =
    get_nth_perm n perm 
    |> convert

    