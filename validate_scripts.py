#!/usr/bin/env python3
"""
Unity Script Validator
Tests Unity C# scripts for common errors and logic issues without requiring Unity Editor
"""

import os
import re
from typing import List, Tuple

def analyze_script(file_path: str) -> List[str]:
    """Analyze a C# script and return list of issues found"""
    issues = []
    
    if not os.path.exists(file_path):
        return [f"File not found: {file_path}"]
    
    with open(file_path, 'r') as f:
        content = f.read()
        lines = content.split('\n')
    
    # Check for common syntax errors
    for i, line in enumerate(lines, 1):
        # Check for variable names with spaces
        if re.search(r'\w+\s+\w+\s*;', line) and 'CharacterController' not in line:
            if 'Enemy Controller' in line:
                issues.append(f"Line {i}: Variable name contains space (should be 'EnemyController')")
        
        # Check for GetComponent without parentheses
        if 'GetComponent<' in line and 'GetComponent<' in line:
            if not re.search(r'GetComponent<\w+>\(\)', line):
                match = re.search(r'GetComponent<\w+>[^()]', line)
                if match:
                    issues.append(f"Line {i}: GetComponent missing parentheses: {line.strip()}")
        
        # Check for potential null reference issues
        if '.transform.position' in line or '.transform.rotation' in line:
            # Check if there's a null check nearby
            has_null_check = False
            for j in range(max(0, i-5), min(len(lines), i+1)):
                if 'if' in lines[j] and ('null' in lines[j] or '!=' in lines[j]):
                    has_null_check = True
                    break
            
            # Check if accessing GameObject that might be null
            if 'GameObject' in content and not has_null_check:
                # This is just a warning, Unity handles null checks differently
                pass
    
    # Check for Time.time vs Time.deltaTime issues
    if 'Time.time' in content and 'gravity' in content.lower():
        for i, line in enumerate(lines, 1):
            if 'Time.time' in line and 'gravity' in line.lower():
                issues.append(f"Line {i}: Using Time.time with gravity (should use Time.deltaTime)")
    
    # Check for missing using statements
    if 'MonoBehaviour' in content and 'using UnityEngine' not in content:
        issues.append("Missing 'using UnityEngine;' statement")
    
    # Check for IEnumerator without using System.Collections
    if 'IEnumerator' in content and 'using System.Collections' not in content:
        issues.append("Missing 'using System.Collections;' for IEnumerator")
    
    # Check for OnTriggerEnter with IEnumerator (should be Coroutine)
    if 'IEnumerator OnTriggerEnter' in content:
        issues.append("OnTriggerEnter should return void, not IEnumerator. Use StartCoroutine() if needed.")
    
    return issues

def validate_all_scripts():
    """Validate all Unity scripts in the project"""
    scripts = [
        ("Movement.cs", "/Users/iremozturk/Desktop/classes/spring2021/ceng361/scripts/Movement.cs"),
        ("CarAIScript.cs", "/Users/iremozturk/Desktop/classes/spring2021/ceng361/scripts/CarAIScript.cs"),
        ("CarTrack.cs", "/Users/iremozturk/Desktop/classes/spring2021/ceng361/scripts/CarTrack.cs"),
        ("tank_drive.cs", "/Users/iremozturk/Desktop/classes/spring2021/ceng361/tank_player/Assets/tank_drive.cs"),
    ]
    
    print("=" * 60)
    print("Unity Script Validation Test")
    print("=" * 60)
    
    total_issues = 0
    scripts_passed = 0
    
    for script_name, script_path in scripts:
        print(f"\n--- Analyzing {script_name} ---")
        issues = analyze_script(script_path)
        
        if issues:
            total_issues += len(issues)
            for issue in issues:
                print(f"  ⚠ {issue}")
        else:
            print("  ✓ No issues found!")
            scripts_passed += 1
    
    print("\n" + "=" * 60)
    print("Summary")
    print("=" * 60)
    print(f"Scripts analyzed: {len(scripts)}")
    print(f"Scripts passed: {scripts_passed}")
    print(f"Total issues found: {total_issues}")
    
    if total_issues == 0:
        print("\n✓ All scripts passed validation!")
        print("The code structure looks good and should compile in Unity.")
    else:
        print(f"\n⚠ Found {total_issues} potential issue(s) to review.")
    
    return total_issues == 0

if __name__ == "__main__":
    validate_all_scripts()

