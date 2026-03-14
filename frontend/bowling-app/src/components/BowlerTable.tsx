import { useEffect, useState } from 'react';
import type { Bowler } from '../types/Bowler';

function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  const fetchBowlers = async () => {
    const response = await fetch('http://localhost:4000/bowler');
    const data = await response.json();
    setBowlers(data);
  };

  useEffect(() => {
    fetchBowlers();
  }, []);

  return (
    <table border={1}>
      <thead>
        <tr>
          <th>First Name</th>
          <th>Middle Init</th>
          <th>Last Name</th>
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
          <tr key={bowler.bowlerID}>
            <td>{bowler.bowlerFirstName}</td>
            <td>{bowler.bowlerMiddleInit}</td>
            <td>{bowler.bowlerLastName}</td>
            <td>{bowler.teamName}</td>
            <td>{bowler.bowlerAddress}</td>
            <td>{bowler.bowlerCity}</td>
            <td>{bowler.bowlerState}</td>
            <td>{bowler.bowlerZip}</td>
            <td>{bowler.bowlerPhoneNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default BowlerTable;
