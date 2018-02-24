let rec powerMN m n = 
    match n with
    | 1 -> m
    | _ -> m * powerMN m (n - 1)

let powerList m n = 
    let rec power acc m = 
        if m < 0 then [] 
        else acc :: power (acc * 2) (m - 1)
    power (powerMN 2 m) n