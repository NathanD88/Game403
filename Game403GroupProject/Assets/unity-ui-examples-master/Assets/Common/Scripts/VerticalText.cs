/* MIT License

Copyright(c) 2017 Lewis Johnson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Common.Scripts {

    [AddComponentMenu("Scripts/Common/Vertical Text")]
    [RequireComponent(typeof(Text))]
    [ExecuteInEditMode]
    public class VerticalText : MonoBehaviour {

        // Use this for initialization
        private void OnEnable() {
            string input = GetComponent<Text>().text;
            StringBuilder sb = new StringBuilder(input.Length * 2);
            foreach (char chr in input) {
                sb.Append(chr).Append("\n");
            }

            GetComponent<Text>().text = sb.ToString();
        }
    }

}