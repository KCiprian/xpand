import { HumanModel } from "../human/HumanModel";
import { RobotModel } from "../robot/RobotModel";

export class PlanetDetailsDto {
    planetId!: number;
    planetName!: string;
    planetDescription!: string;
    planetImage!: BigInt64Array;
    planetStatus!: number;
    robots!: RobotModel[];
    captains!: HumanModel[];
}