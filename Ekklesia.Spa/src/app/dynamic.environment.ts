declare var window: any;

export class DynamicEnviroment {

    public get enviroment() {
        return window.config;
    }
}
