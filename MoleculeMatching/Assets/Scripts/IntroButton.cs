using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Molecule Matcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */

public class IntroButton : MonoBehaviour
{

    [SerializeField]
    private string title= "Title";
    private string demo = "Demo";
    public void StartDemo()
    {
        SceneManager.LoadScene(demo);
    }

    public void RestartDemo()
    {
        SceneManager.LoadScene(title);
    }
}
