import './App.css';
import { useState } from 'react';
import type { bowler } from './types/bowler'; // Importing the bowler type

function BowlerList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  const fetchBowlers = async () => {
    const response = await fetch('https://localhost:7277/api/Bowlers');

    const data = await response.json();
    const filteredData = data.filter(
      (bowler: { team?: { teamName?: string } }) =>
        bowler.team?.teamName === 'Marlins' ||
        bowler.team?.teamName === 'Sharks'
    );

    setBowlers(filteredData);
  };

  fetchBowlers();

  return (
    <>
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Team</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler) => (
            <tr key={bowler.bowlerId}>
              <td>
                {`${bowler.bowlerFirstName} ${bowler.bowlerMiddleInit || ''} ${bowler.bowlerLastName}`.trim()}
              </td>
              <td>{bowler.team?.teamName || 'N/A'}</td>
              <td>{bowler.bowlerCity}</td>
              <td>{bowler.bowlerState}</td>
              <td>{bowler.bowlerZip}</td>
              <td>{bowler.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlerList;
