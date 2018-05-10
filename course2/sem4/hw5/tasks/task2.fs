namespace tasks

module task2 = 
        
    let func'0 x l = List.map (fun y -> y * x) l

    let func'1 x : int list -> int list = 
        List.map (fun y -> y * x) 
    
    let func'2 x : int list -> int list = 
        List.map (fun y -> ((*) y x))

    let func'3 x : int list -> int list = 
        List.map (fun y -> ((*) x) y)

    let func'4 x: int list -> int list = 
        List.map ((*) x)

    let func'5: int -> int list -> int list = 
        List.map << (*)