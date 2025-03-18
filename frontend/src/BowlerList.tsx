import './App.css';
import { useState, useEffect } from 'react';
import type { bowler } from './types/bowler'; // Importing the bowler type

function BowlerList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  useEffect(() => {
    const fetchBowlers = async () => {
      // This gets the data from the backend
      const response = await fetch('https://localhost:5000/api/Bowlers');

      const data = await response.json();

      // This filters the data so it is only players from Marlins and Sharks
      const filteredData = data.filter(
        (bowler: { team?: { teamName?: string } }) =>
          bowler.team?.teamName === 'Marlins' ||
          bowler.team?.teamName === 'Sharks'
      );

      setBowlers(filteredData);
    };
    fetchBowlers();
  }, []);

  // Returns the table filled with data
  return (
    <>
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Team</th>
            <th>Address</th>
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
              <td>{bowler.bowlerAddress}</td>
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
