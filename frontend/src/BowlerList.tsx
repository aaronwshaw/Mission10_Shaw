import { useState } from 'react';
import type { bowler } from './types/bowler'; // Importing the bowler type from the combined file

function BowlerList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  const fetchBowlers = async () => {
    const response = await fetch('https://localhost:7277/api/Bowlers');
    const data = await response.json();
    const filtereddata = data.filter(
      (bowler: { teamName: string }) =>
        bowler.teamName === 'Marlins' || bowler.teamName === 'Sharks'
    );
    setBowlers(filtereddata);
  };
  fetchBowlers();
  return (
    <table className="w-full border-collapse border border-gray-400 mt-4">
      <thead>
        <tr className="bg-gray-200">
          <th className="border p-2">Name</th>
          <th className="border p-2">Team</th>
          <th className="border p-2">City</th>
          <th className="border p-2">State</th>
          <th className="border p-2">Zip</th>
          <th className="border p-2">Phone</th>
        </tr>
      </thead>
      <tbody>
        {bowlers.length > 0 ? (
          bowlers.map((bowler) => (
            <tr key={bowler.bowlerId} className="border">
              <td className="border p-2">
                {`${bowler.bowlerFirstName} ${bowler.bowlerMiddleInit || ''} ${bowler.bowlerLastName}`.trim()}
              </td>
              <td>{bowler.team?.teamName || 'N/A'}</td>
              <td>{bowler.bowlerCity}</td>
              <td>{bowler.bowlerState}</td>
              <td>{bowler.bowlerZip}</td>
              <td>{bowler.bowlerPhoneNumber}</td>
            </tr>
          ))
        ) : (
          <tr></tr>
        )}
      </tbody>
    </table>
  );
}

export default BowlerList;
