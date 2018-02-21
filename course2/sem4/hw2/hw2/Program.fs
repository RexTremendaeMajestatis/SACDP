(*2.1*)

let count n = 
    let rec recCount n acc = 
        if n = 0 then acc
        else acc * recCount (n / 10) (n % 10)
    recCount n 1