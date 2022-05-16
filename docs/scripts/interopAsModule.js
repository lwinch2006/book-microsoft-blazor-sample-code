let get = key => key in localStorage ? JSON.parse(localStorage[key]) : null;

let set = (key, value) => {
        localStorage[key] = JSON.stringify(value);
    };

let deleteData = key => {
    delete localStorage[key]
};

let watch = async (instance) => {
    window.addEventListener('storage', (e) => {
        instance.invokeMethodAsync('UpdateCounter');
    })
};

export {get, set, deleteData, watch};
