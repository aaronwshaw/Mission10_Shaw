export type team = {
    teamId: number;
    teamName: string;
    captainId?: number | null; // Optional because it's nullable in C#
  };
  
  export type bowler = {
    bowlerId: number;
    bowlerLastName: string;
    bowlerFirstName: string;
    bowlerMiddleInit?: string; // Made optional since it may be null
    bowlerAddress: string;
    bowlerCity: string;
    bowlerState: string;
    bowlerZip: string;
    bowlerPhoneNumber: string;
    teamId: number;
    team?: team; // Added a reference to Team
  };
  