using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Molecule Matcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */

public class ResetMolecule : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject molecule;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision");
        if (collider.CompareTag("Molecule"))
        {
            molecule.transform.position = new Vector2(0, 1);
        }

    }
}
