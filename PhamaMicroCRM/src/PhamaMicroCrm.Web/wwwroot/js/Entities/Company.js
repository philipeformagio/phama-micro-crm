class Company {
    constructor(name, field, active, phone) {
        this.name = name;
        this.field = field;
        this.active = active;
        this.phone = phone;
    }

    //methods
    greet() {
        console.log(`Hi, I'm a company called ${this.name}`);
    }   
}